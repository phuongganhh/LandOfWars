using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceHelper
{
    public class MyComponent
    {
        public string content { get; set; }
        public string tabName { get; set; }
        public string name { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.getAsm().ToList().ForEach(item =>
            {
                this.dataGridView1.Rows.Add(new object[] { item.Name });
            });
            var btn = new Button();
            btn.Text = "Export ALL";
            btn.Click += Btn_Click;
            this.grButton.Controls.Add(btn);
            this.dataGridView1.CellClick += DataGridView1_CellClick;
            this.tabControl1.TabPages.Clear();
        }


        private void addTab(List<MyComponent> text)
        {
            this.tabControl1.TabPages.Clear();
            text.ForEach(item =>
            {
                var tabPage = new TabPage(item.tabName);
                var richTextBox = new RichTextBox();
                richTextBox.Name = item.tabName;
                richTextBox.Dock = DockStyle.Fill;
                richTextBox.AppendText(item.content);
                tabPage.Controls.Add(richTextBox);
                this.tabControl1.TabPages.Add(tabPage);

            });
        }
        private FileInfo GetEntities()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            DirectoryInfo mvcAppDirectory = new DirectoryInfo(Path.GetDirectoryName(asm.CodeBase.Replace("file:///", "")));
            return mvcAppDirectory.GetFiles("*.dll")
                .FirstOrDefault(x => x.Name.StartsWith("PA.Entities"));
        }
        private IEnumerable<Type> getAsm()
        {
            if (asm == null)
                asm = Assembly.LoadFile(GetEntities().FullName).ExportedTypes;
            return asm;
        }
        private static IEnumerable<Type> asm { get; set; }
        private string getFile(string FileName)
        {
            var result = "";
            using (var r = new StreamReader(FileName))
            {
                result = r.ReadToEnd();
            }
            return result;
        }
        private string UpperCaseName(string name)
        {
            var text = "";
            name.Split('_').Select(x =>
            {
                var firstName = x.ToUpper()[0];
                return $"{firstName}{x.Remove(0, 1)}";
            })
            .ToList()
            .ForEach(item =>
            {
                text += item;
            });
            return text;
        }
        private string getController(string controllerName)
        {
            var text = this.getFile(@"Components\Controllers.txt");
            return text.Replace("{ControllerName}", this.UpperCaseName(controllerName));
        }
        private string getTypeOf(Type type)
        {
            if(type == typeof(string))
            {
                return "string";
            }
            else if(type == typeof(int?))
            {
                return "int?";
            }
            else if(type == typeof(DateTime?))
            {
                return "DateTime?";
            }
            else if(type == typeof(long?))
            {
                return "long?";
            }
            else
            {
                return "UnKnown";
            }
        }
        private string getModel(string controllerName, string fileName,bool leftJoin = false)
        {
            var text = this.getFile(string.Format(@"Components\{0}.txt", fileName));
            StringBuilder builder = new StringBuilder();
            var typeId = this.getTypeOf(this.getAsm().FirstOrDefault(x => x.Name == controllerName).GetProperties().FirstOrDefault().PropertyType);
            var id = this.getAsm().FirstOrDefault(x => x.Name == controllerName).GetProperties().FirstOrDefault().Name;
            if (leftJoin)
            {
                var asm = this.getAsm().FirstOrDefault(x => x.Name == controllerName);
                var prop = asm.GetProperties().Where(x => x.Name.EndsWith("_id") && this.getAsm().Any(a=>a.Name == x.Name.Replace("_id",""))).ToList();
                prop.ForEach(s =>
                {
                    var name = s.Name.Replace("_id", "");
                    var property = this.getAsm().FirstOrDefault(x => x.Name == name).GetProperties();
                    builder.AppendLine(string.Format("\t\t.LeftJoin(\"{0}\",\"{1}\",\"{2}\")",name,name+".id",controllerName + "." + s.Name));
                });
                builder.AppendLine("\t\t\t\t.Select(");
                //builder.AppendLine($"\"{controllerName}.*\",");
                asm.GetProperties().ToList().ForEach(item =>
                {
                    builder.AppendLine($"\t\t\t\t\t\"{controllerName}.{item.Name}\",");
                });
                prop.ForEach(p =>
                {
                    var name = p.Name.Replace("_id", "");
                    this.getAsm().FirstOrDefault(x => x.Name == name).GetProperties().ToList().ForEach(item =>
                      {
                          if(p.Name != name + "_" + item.Name)
                            builder.AppendLine(string.Format("\t\t\"{0} as {1}\",", name+ "."+ item.Name, name + "_" + item.Name));
                      });
                });
                var texts = builder.ToString().Remove(builder.Length - 3, 3);
                builder.Clear();
                builder.Append(texts);
                builder.Append(Environment.NewLine);
                builder.Append("\t\t\t\t)");
            }
            var loopProperty = new StringBuilder();
            var loopWhere = new StringBuilder();
            if (fileName.EndsWith("SearchRepository"))
            {
                this.getAsm().FirstOrDefault(x => x.Name == controllerName).GetProperties().ToList().ForEach(item =>
                {
                    loopWhere.AppendLine($"\t\t\tif(this.{item.Name} != null)");
                    loopWhere.AppendLine("\t\t\t{");
                    loopWhere.AppendLine($"\t\t\t\tresult = result.WhereLike(\"{controllerName}.{item.Name}\",\"%\" + this.{item.Name}.ToString() + \"%\");");
                    loopWhere.AppendLine("\t\t\t}");
                    loopProperty.AppendLine($"\t\tpublic {this.getTypeOf(item.PropertyType)} {item.Name} " + "{ get; set; }");
                });
            }
            return text
                .Replace("{ControllerName}", this.UpperCaseName(controllerName))
                .Replace("{DefaultControllerName}", controllerName)
                .Replace("{LeftJoin}",builder.ToString())
                .Replace("{ID}",id)
                .Replace("{TypeID}",typeId)
                .Replace("{loopProperty}",loopProperty.ToString())
                .Replace("{loopWhere}",loopWhere.ToString())
                ;
        }
        private List<MyComponent> componentss { get; set; }
        private List<MyComponent> myComponents
        {
            get
            {
                var m = new List<MyComponent>();
                this.getAsm().ToList().ForEach(item =>
                {
                    var name = item.Name;
                    m.Add(new MyComponent
                    {
                        content = this.getController(name),
                        tabName = this.UpperCaseName(name) + "Controller",
                        name = name
                    });
                    m.Add(new MyComponent
                    {
                        content = this.getModel(name, "ModelDeleteByIdRepository"),
                        tabName = this.UpperCaseName(name) + "DeleteByIdRepository",
                        name = name
                    });
                    m.Add(new MyComponent
                    {
                        content = this.getModel(name, "ModelUpdateByIdRepository"),
                        tabName = this.UpperCaseName(name) + "UpdateByIdRepository",
                        name = name
                    });
                    m.Add(new MyComponent
                    {
                        content = this.getModel(name, "ModelInsertRepository"),
                        tabName = this.UpperCaseName(name) + "InsertRepository",
                        name = name
                    });
                    m.Add(new MyComponent
                    {
                        content = this.getModel(name, "ModelSearchRepository", true),
                        tabName = this.UpperCaseName(name) + "SearchRepository",
                        name = name
                    });
                    m.Add(new MyComponent
                    {
                        content = this.getModel(name, "ModelGetByIdRepository", true),
                        tabName = this.UpperCaseName(name) + "GetByIdRepository",
                        name = name
                    });
                    m.Add(new MyComponent
                    {
                        content = this.getModel(name, "DeleteByIdAction"),
                        tabName = this.UpperCaseName(name) + "DeleteByIdAction",
                        name = name
                    });
                    m.Add(new MyComponent
                    {
                        content = this.getModel(name, "UpdateByIdAction"),
                        tabName = this.UpperCaseName(name) + "UpdateByIdAction",
                        name = name
                    });
                    m.Add(new MyComponent
                    {
                        content = this.getModel(name, "InsertAction"),
                        tabName = this.UpperCaseName(name) + "InsertAction",
                        name = name
                    });
                    m.Add(new MyComponent
                    {
                        content = this.getModel(name, "SearchAction", true),
                        tabName = this.UpperCaseName(name) + "SearchAction",
                        name = name
                    });
                    m.Add(new MyComponent
                    {
                        content = this.getModel(name, "GetByIdAction", true),
                        tabName = this.UpperCaseName(name) + "GetByIdAction",
                        name = name
                    });
                });
                return m;
            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView grid = (DataGridView)sender;
                var name = grid.CurrentRow.Cells[0].Value.ToString();
                var propertyInfos = this.getAsm().FirstOrDefault(x => x.Name == name).GetProperties();
                componentss = new List<MyComponent>();
                componentss.Add(new MyComponent
                {
                    content = this.getController(name),
                    tabName = this.UpperCaseName(name) + "Controller",
                    name = name
                });
                componentss.Add(new MyComponent
                {
                    content = this.getModel(name, "ModelDeleteByIdRepository"),
                    tabName = this.UpperCaseName(name) + "DeleteByIdRepository",
                    name = name
                });
                componentss.Add(new MyComponent
                {
                    content = this.getModel(name, "ModelUpdateByIdRepository"),
                    tabName = this.UpperCaseName(name) + "UpdateByIdRepository",
                    name = name
                });
                componentss.Add(new MyComponent
                {
                    content = this.getModel(name, "ModelInsertRepository"),
                    tabName = this.UpperCaseName(name) + "InsertRepository",
                    name = name
                });
                componentss.Add(new MyComponent
                {
                    content = this.getModel(name, "ModelSearchRepository",true),
                    tabName = this.UpperCaseName(name) + "SearchRepository",
                    name = name
                });
                componentss.Add(new MyComponent
                {
                    content = this.getModel(name, "ModelGetByIdRepository",true),
                    tabName = this.UpperCaseName(name) + "GetByIdRepository",
                    name = name
                });
                this.addTab(componentss);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if(this.myComponents != null)
            {
                
                this.myComponents.ForEach(file =>
                {
                    var pathController = $"{Directory.GetCurrentDirectory()}\\Export\\Controllers\\";
                    var pathRepos = $"{Directory.GetCurrentDirectory()}\\Export\\Repository\\";
                    var pathModel = $"{Directory.GetCurrentDirectory()}\\Export\\Models\\";
                    
                    if (file.tabName.EndsWith("Controller"))
                    {
                        if (!Directory.Exists(pathController))
                        {
                            Directory.CreateDirectory(pathController);
                        }
                        using (var w = new StreamWriter(pathController + file.tabName + ".cs"))
                        {
                            w.Write(file.content);
                        }
                    }
                    else if (file.tabName.EndsWith("Repository"))
                    {
                        if (!Directory.Exists(pathRepos + file.name))
                        {
                            Directory.CreateDirectory(pathRepos + file.name);
                        }
                        using (var w = new StreamWriter(pathRepos + "\\" + file.name + "\\" + file.tabName + ".cs"))
                        {
                            w.Write(file.content);
                        }
                    }
                    else if (file.tabName.EndsWith("Action"))
                    {
                        if (!Directory.Exists(pathModel + file.name))
                        {
                            Directory.CreateDirectory(pathModel + file.name);
                        }
                        using (var w = new StreamWriter(pathModel + "\\" + file.name + "\\" + file.tabName + ".cs"))
                        {
                            w.Write(file.content);
                        }
                    }
                    
                });
                Process.Start(Directory.GetCurrentDirectory() + @"\Export");
            }
        }
    }
}
