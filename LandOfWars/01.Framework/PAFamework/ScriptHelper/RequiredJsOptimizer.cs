using System;
using System.Collections.Generic;
using System.Linq;

namespace PA.Framework.ScriptHelper
{
    public class RequiredJsDescription
    {
        public string Name { get; set; }
        public string PAth { get; set; }
        public string[] Dependencies { get; set; }
        public bool WithoutVersion { get; set; }
    }

    public static class RequiredJsOptimizer
    {
        public static string BaseUrl { get; set; }
        public static List<RequiredJsDescription> RequiredJsModules { get; private set; }

        static RequiredJsOptimizer()
        {
            InitModules();
        }

        private static string GetPAthWithBaseUrl(string PAth)
        {
            return StringBuilderPool.ProcessWithResult(sb =>
            {
                sb.Append(BaseUrl);
                sb.Append("/");
                sb.Append(PAth);
                sb.Append(".js");
            });
        }

        private static string GetVersionPAth(string PAth)
        {
            string withVersionPAth = Optimizer.Url(GetPAthWithBaseUrl(PAth));
            string version = withVersionPAth.Split('?').Last();
            return string.Format("{0}.js?{1}", PAth, version);
        }

        public static string BuildRequiredJsConfig()
        {
            string stringTemplate = "'{0}'";
            string propStringTemplate = "{0}: '{1}',";
            string proPArrayTemplate = "{0}: [{1}],";
            string PAths = string.Empty, shim = string.Empty;
            StringBuilderPool.Process((sb1, sb2) =>
            {
                foreach (var module in RequiredJsModules)
                {
                    string PAth = !module.WithoutVersion ? GetVersionPAth(module.PAth) : module.PAth;
                    sb1.AppendFormat(propStringTemplate, module.Name, PAth);
                    if (module.Dependencies != null)
                        sb2.AppendFormat(
                            proPArrayTemplate,
                            module.Name,
                            String.Join(",", module.Dependencies.Select(x => string.Format(stringTemplate, x)))
                            );
                }
                PAths = sb1.ToString();
                shim = sb2.ToString();
            });

            return StringBuilderPool.ProcessWithResult(sb =>
            {
                sb.Append("require.config({");
                sb.Append("    baseUrl: '/Content/js',");
                sb.Append("    PAths: {");
                sb.Append(PAths);
                sb.Append("    },");
                sb.Append("    shim: {");
                sb.Append(shim);
                sb.Append("    }");
                sb.Append("});");
            });
        }

        private static void InitModules()
        {
            BaseUrl = "/Content/js";
            RequiredJsModules = new List<RequiredJsDescription> {
                new RequiredJsDescription
                {
                    Name="JqueryValidate",
                    PAth="../flaty/assets/jquery-validation/dist/jquery.validate.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="BootstrapToggle",
                    PAth="../flaty/assets/bootstrap-toggle/bootstrap-toggle.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="framework",
                    PAth="framework",
                    Dependencies= new string[]{ "widget", "global", "common" }
                },
                new RequiredJsDescription
                {
                    Name="common",
                    PAth="framework.common",
                },
                new RequiredJsDescription
                {
                    Name="global",
                    PAth="framework.global",
                },
                new RequiredJsDescription
                {
                    Name="links",
                    PAth="framework.common.links",
                    Dependencies= new string[]{ "framework", "widget", "global", "common" }
                },
                new RequiredJsDescription
                {
                    Name="inputPAge",
                    PAth="framework.layout.inputPAge",
                    Dependencies= new string[]{ "framework", "widget" }
                },
                new RequiredJsDescription
                {
                    Name="listPAge",
                    PAth="framework.layout.listPAge",
                    Dependencies= new string[]{ "framework", "widget", "PAnel" }
                },
                new RequiredJsDescription
                {
                    Name="widget",
                    PAth="widget.setting",
                },
                new RequiredJsDescription
                {
                    Name="layout",
                    PAth="layout.setting",
                    Dependencies= new string[]{ "global", "widget"}
                },
                new RequiredJsDescription
                {
                    Name="domReady",
                    PAth="../plugins/requirejs/domReady",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="base",
                    PAth="widget/widget.base",
                },
                new RequiredJsDescription
                {
                    Name="button",
                    PAth="widget/widget.button",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="calendar",
                    PAth="widget/widget.calendar",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="colorselect",
                    PAth="widget/widget.colorselect",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="TabContainer",
                    PAth="widget/widget.TabContainer",
                    Dependencies = new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="form",
                    PAth="widget/widget.form",
                    Dependencies=new string[]{ "base", "popupField", "multicodeField", "linkTextField" }
                },

                new RequiredJsDescription
                {
                    Name="thumbnailImage",
                    PAth="widget/widget.thumbnailImage",
                    Dependencies=new string[]{ "base"}
                },
                new RequiredJsDescription
                {
                    Name="PAgination",
                    PAth="widget/widget.PAgination",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="PAnel",
                    PAth="widget/widget.PAnel",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="PAnelChart",
                    PAth="widget/widget.PAnelChart",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="grid",
                    PAth="widget/widget.grid",
                    Dependencies=new string[]{ "base", "PAgination", "gridRenderType","jqueryContextMenu" }
                },
                new RequiredJsDescription
                {
                    Name="texteditor",
                    PAth="widget/widget.texteditor",
                    Dependencies=new string[]{ "base", "ckeditor" }
                },
                new RequiredJsDescription
                {
                    Name="gallery",
                    PAth="widget/widget.gallery",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="uploader",
                    PAth="widget/widget.uploader",
                },
                new RequiredJsDescription
                {
                    Name="tabs",
                    PAth="widget/widget.tabs",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="FileThumbnail",
                    PAth="widget/widget.FileThumbnail",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="boxcontent",
                    PAth="widget/widget.boxcontent",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="checkboxTable",
                    PAth="widget/widget.checkboxTable",
                    Dependencies=new string[]{ "base", "stringJs" }
                },
                new RequiredJsDescription
                {
                    Name="pluploadCustom",
                    PAth="widget/widget.pluploadCustom",
                    Dependencies=new string[]{ "base", "pluploadcore", "pluploadui" }
                },
                new RequiredJsDescription
                {
                    Name="MindMapTree",
                    PAth="widget/widget.MindMapTree",
                    Dependencies=new string[]{ "base", "gojs" }
                },
                new RequiredJsDescription
                {
                    Name="jsbarcode",
                    PAth="../plugins/JsBarcode/JsBarcode.all.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="gojs",
                    PAth="../plugins/goJS/go-debug",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="amcharts",
                    PAth="../plugins/amcharts/amcharts",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="amcharts_serial",
                    PAth="../plugins/amcharts/serial",
                    Dependencies = new string[]{ "amcharts" },
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="amcharts_light",
                    PAth="../plugins/amcharts/themes/light",
                    Dependencies=new string[]{ "amcharts" },
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="amcharts_export",
                    PAth="../plugins/amcharts/plugins/export/export.min",
                    Dependencies = new string[]
                    {
                        "amcharts",
                        "amcharts_export_blob",
                        "amcharts_export_fabric",
                        "amcharts_export_fileSaver",
                        "amcharts_export_jszip",
                        "amcharts_export_pdfmake",
                        "amcharts_export_pdfFonts",
                        "amcharts_export_xlsx"
                    },
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="amcharts_export_blob",
                    PAth="../plugins/amcharts/plugins/export/libs/blob.js/blob",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="amcharts_export_fabric",
                    PAth="../plugins/amcharts/plugins/export/libs/fabric.js/fabric.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="amcharts_export_fileSaver",
                    PAth="../plugins/amcharts/plugins/export/libs/FileSaver.js/FileSaver.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="amcharts_export_jszip",
                    PAth="../plugins/amcharts/plugins/export/libs/jszip/jszip.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="amcharts_export_pdfmake",
                    PAth="../plugins/amcharts/plugins/export/libs/pdfmake/pdfmake.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="amcharts_export_pdfFonts",
                    PAth="../plugins/amcharts/plugins/export/libs/pdfmake/vfs_fonts",
                    Dependencies = new string[]{ "amcharts_export_pdfmake" },
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="amcharts_export_xlsx",
                    PAth="../plugins/amcharts/plugins/export/libs/xlsx/xlsx.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="AmChartLine",
                    PAth="widget/widget.AmChartLine",
                    Dependencies=new string[]{ "base", "amcharts", "amcharts_serial", "amcharts_export", "amcharts_light", },
                },
                new RequiredJsDescription
                {
                    Name="ChartGeneral",
                    PAth="widget/widget.ChartGeneral",
                    Dependencies=new string[]{ "base", "amcharts", "amcharts_serial", "amcharts_export", "amcharts_light", },
                },
                new RequiredJsDescription
                {
                    Name="AmChartColumn",
                    PAth="widget/widget.AmChartColumn",
                    Dependencies=new string[]{ "base", "amcharts", "amcharts_serial", "amcharts_export", "amcharts_light", },
                },
                new RequiredJsDescription
                {
                    Name="barcode",
                    PAth="widget/widget.barcode",
                    Dependencies=new string[]{ "jsbarcode" },
                },
                new RequiredJsDescription
                {
                    Name="titleToolbar",
                    PAth="widget/widget.titleToolbar",
                },
                new RequiredJsDescription
                {
                    Name="gridRenderType",
                    PAth="widget/widget.grid.rendertype",
                },
                new RequiredJsDescription
                {
                    Name="chatConversation",
                    PAth="widget/widget.chatConversation",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="reportGrid",
                    PAth="widget/widget.reportGrid",
                    Dependencies=new string[]{ "base","grid" }
                },
                new RequiredJsDescription
                {
                    Name="chatUserList",
                    PAth="widget/widget.chatUserList",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="PAnelBox",
                    PAth="widget/widget.PAnelBox",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="PAnelDashboard",
                    PAth="widget/widget.PAnelDashboard",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="userCurrent",
                    PAth="widget/widget.userCurrent",
                    Dependencies=new string[]{ "base" }
                },
                new RequiredJsDescription
                {
                    Name="popupField",
                    PAth="w2uiCustomFieldType/widgetConfigField",
                },
                new RequiredJsDescription
                {
                    Name="multicodeField",
                    PAth="w2uiCustomFieldType/widgetConfigMulticodeField",
                },
                new RequiredJsDescription
                {
                    Name="linkTextField",
                    PAth="w2uiCustomFieldType/linktextField",
                },
                new RequiredJsDescription
                {
                    Name="ckeditor",
                    PAth="../plugins/ckeditor-492-math/ckeditor",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="pluploadcore",
                    PAth="../plugins/plupload-2.1.9/js/plupload.full.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="pluploadui",
                    PAth="../plugins/plupload-2.1.9/js/jquery.ui.plupload/jquery.ui.plupload.min",
                    Dependencies=new string[]{ "pluploadcore" },
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="stringJs",
                    PAth="../plugins/stringJs/String",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="linkGoogleAPI",
                    PAth="https://apis.google.com/js/api",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="ej2Schedule",
                    PAth="../plugins/syncfusion-schedule/ej2.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="googlePicker",
                    PAth="widget/widget.googlePicker",
                    Dependencies=new string[]{ "base", "linkGoogleAPI" }
                },
                new RequiredJsDescription
                {
                    Name="roomMap",
                    PAth="widget/widget.roomMap",
                    Dependencies=new string[]{ "base", "jqueryContextMenu" },
                },
                new RequiredJsDescription
                {
                    Name="roomCalendar",
                    PAth="widget/widget.roomCalendar",
                    Dependencies=new string[]{ "base" },
                },
                new RequiredJsDescription
                {
                    Name="RoomOrderCalendar",
                    PAth="widget/widget.RoomOrderCalendar",
                    Dependencies=new string[]{ "base", "ej2Schedule" }, //"json!../plugins/syncfusion-schedule/vi.json"
                },
                new RequiredJsDescription
                {
                    Name="RoomOrderDashboard",
                    PAth="widget/widget.RoomOrderDashboard",
                    Dependencies=new string[]{ "base", "https://ej2.syncfusion.com/javascript/demos/schedule/timeline-resources/datasource.js", "ej2Schedule" }, //"json!../plugins/syncfusion-schedule/vi.json"
                },
                new RequiredJsDescription
                {
                    Name="assignment",
                    PAth="widget/widget.assignment",
                    Dependencies=new string[]{ "base" },
                },
                new RequiredJsDescription
                {
                    Name="viewExam",
                    PAth="widget/widget.viewExam",
                    Dependencies=new string[]{ "base" },
                },
                new RequiredJsDescription
                {
                    Name="pieChart",
                    PAth="widget/widget.pieChart",
                    Dependencies=new string[]{ "goog!visualization,1.1,PAckages:[corechart],language:vi","base" },
                },
                 new RequiredJsDescription
                {
                    Name="lineChart",
                    PAth="widget/widget.lineChart",
                    Dependencies=new string[]{ "goog!visualization,1.1,PAckages:[corechart, line],language:vi", "base" },
                },
                new RequiredJsDescription
                {
                    Name="columnChart",
                    PAth="widget/widget.columnChart",
                    Dependencies=new string[]{ "goog!visualization,1.1,PAckages:[corechart, bar],language:vi", "base" },
                },
                new RequiredJsDescription
                {
                    Name="ganttChart",
                    PAth="widget/widget.ganttChart",
                    Dependencies=new string[]{ "goog!visualization,1.1,PAckages:[gantt],language:vi" },
                },
                new RequiredJsDescription
                {
                    Name="timelineChart",
                    PAth="widget/widget.timelineChart",
                    Dependencies=new string[]{ "goog!visualization,1.1,PAckages:[timeline],language:vi" },
                },
                new RequiredJsDescription
                {
                    Name="tableHTML",
                    PAth="widget/widget.tableHTML",
                    Dependencies=new string[]{ "base" },
                },
                new RequiredJsDescription
                {
                    Name="Merchant",
                    PAth="widget/widget.Merchant",
                    Dependencies=new string[]{ "base" },
                },
                new RequiredJsDescription
                {
                    Name="printRoomOrder",
                    PAth="widget/widget.printRoomOrder",
                    Dependencies=new string[]{ "base" },
                },
                new RequiredJsDescription
                {
                    Name="formWizard",
                    PAth="widget/widget.formWizard",
                    Dependencies=new string[]{ "base", "JqueryValidate","JqueryBackstretch","retina" },
                },
                new RequiredJsDescription {
                    Name = "async",
                    PAth = "../plugins/requirejs/plugins/src/async",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "font",
                    PAth = "../plugins/requirejs/plugins/src/font",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "JqueryBackstretch",
                    PAth = "../plugins/FormWizard/jquery.backstretch.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "retina",
                    PAth = "../plugins/FormWizard/retina-1.1.0.min",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "goog",
                    PAth = "../plugins/requirejs/plugins/src/goog",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "image",
                    PAth = "../plugins/requirejs/plugins/src/image",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "json",
                    PAth = "../plugins/requirejs/plugins/src/json",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "noext",
                    PAth = "../plugins/requirejs/plugins/src/noext",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "mdown",
                    PAth = "../plugins/requirejs/plugins/src/mdown",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "propertyPArser",
                    PAth = "../plugins/requirejs/plugins/src/propertyPArser",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "text", // Load JSON files and PArses the result
                    PAth = "../plugins/requirejs/plugins/lib/text",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "markdownConverter",
                    PAth = "../plugins/requirejs/plugins/src/Markdown.Converter",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "jqueryUIPosition",
                    PAth = "../plugins/Jquery-ContextMenu/jquery.ui.position",
                    WithoutVersion=true
                },
                new RequiredJsDescription {
                    Name = "jqueryContextMenu",
                    PAth = "../plugins/Jquery-ContextMenu/jquery.contextMenu",
                    Dependencies = new string[]{ "jqueryUIPosition" },
                    WithoutVersion=true
                },
                new RequiredJsDescription
                {
                    Name="customScroller",
                    PAth="../plugins/custom-scroller/jquery.mCustomScrollbar",
                    WithoutVersion=true
                },
            };
        }
    }
}