using PA.Caching;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PA
{
    public interface ICommand : IDisposable
    {
        Result Execute(ObjectContext context);
    }

    public interface ICommand<T> : IDisposable
    {
        Result<T> Execute(ObjectContext context);
    }

    public abstract class CommandBase : ICommand
    {
        //protected IUnitOfWork UnitOfWork { get; private set; }
        //protected IAqDatabase DefaultDb { get; private set; }

        //public CommandBase()
        //{
        //    UnitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>();
        //    DefaultDb = UnitOfWork.GetDatabase();
        //}

        /// <summary>
        /// Validate before execute a command. Base validation does nothing
        /// </summary>
        protected virtual void ValidateCore(ObjectContext context)
        {
        }
        protected virtual void OnExecutingCore(ObjectContext context)
        {
        }
        protected virtual void OnExecutedCore(ObjectContext context, Result result)
        {
        }
        protected abstract Result ExecuteCore(ObjectContext context);
        public Result Execute(ObjectContext context)
        {
            try
            {
                ValidateCore(context);
                OnExecutingCore(context);
                var result = ExecuteCore(context);
                OnExecutedCore(context, result);
                return result;
            }
            catch (BusinessException ex)
            {
                return new Result
                {
                    is_success = true,
                    error_code = (int)ex.exit_code,
                    msg = ex.Message
                };
            }
            catch(HttpException ex)
            {
                return new Result
                {
                    is_success = true,
                    error_code = ex.GetHttpCode(),
                    msg = ex.Message
                };
            }
            catch(Exception ex)
            {
                return new Result
                {
                    is_success = false,
                    error_code = (int)HttpStatusCode.InternalServerError,
                    msg = ex.Message,
                    description = ex.StackTrace
                };
            }
            finally
            {
                
            }
        }

        public virtual void Dispose()
        {
        }

        protected Result Success(string message = "Success")
        {
            return new Result
            {
                is_success = true,
                error_code = 0,
                msg = message
            };
        }
    }

    public abstract class CommandBase<T> : ICommand<T>
    {

        /// <summary>
        /// Validate before execute a command. Base validation does nothing
        /// </summary>
        protected virtual void ValidateCore(ObjectContext context)
        {
        }
        protected virtual void OnExecutingCore(ObjectContext context)
        {
        }
        protected virtual void OnExecutedCore(ObjectContext context, Result<T> result)
        {
        }
        protected abstract Result<T> ExecuteCore(ObjectContext context);
        public Result<T> Execute(ObjectContext context)
        {
            try
            {
                ValidateCore(context);
                OnExecutingCore(context);
                var result = ExecuteCore(context);
                OnExecutedCore(context, result);
                return result;
            }
            catch (BusinessException ex)
            {
                return new Result<T>
                {
                    is_success = true,
                    error_code = (int)ex.exit_code,
                    msg = ex.Message
                };
            }
            catch (HttpException ex)
            {
                return new Result<T>
                {
                    is_success = true,
                    error_code = ex.GetHttpCode(),
                    msg = ex.Message
                };
            }
            catch (Exception ex)
            {
                return new Result<T>
                {
                    is_success = false,
                    error_code = (int)HttpStatusCode.InternalServerError,
                    msg = ex.Message,
                    description = ex.StackTrace
                };
            }
        }
        public virtual void Dispose()
        {
        }
        
        protected Result<T> Success(T data, string message = "Success")
        {
            return new Result<T>
            {
                data = data,
                error_code = 0,
                msg = message,
                is_success = true
            };
        }
    }

    public interface IResult
    {
        string msg { get; set; }
        bool? is_success { get; set; }
        int? error_code { get; set; }
    }

    public interface IResult<T> : IResult
    {
        T data { get; set; }
    }

    public class Result : IResult
    {
        public bool? is_success { get; set; }
        public string msg { get; set; }
        public int? error_code { get; set; }
        public string description { get; set; }
        public Result()
        {
            this.error_code = 0;
            this.msg = "Success";
            this.is_success = true;
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        public T data { get; set; }
        public IPaging paging { get; set; }
    }

    public interface IPaging
    {
        long? total { get; set; }
        long? current_page { get; set; }
        long? page_size { get; set; }
    }

    public class Paging<T> : IPaging, IResult<List<T>>
    {
        public List<T> data { get;set; }
        public string msg { get;set; }
        public bool? is_success { get;set; }
        public int? error_code { get; set; }
        public long? total { get;set; }
        public long? current_page { get;set; }
        public long? page_size { get;set; }
    }
    public interface IPaginableBusiness<T> : ICommand<List<T>>
    {
        int? Total { get; set; }
        int? CurrentPage { get; set; }
        int? PAgeSize { get; set; }
        List<T> Data { get; set; }
    }

}
