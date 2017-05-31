using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LimestoneDigitalTask.Models.DTO;

namespace LimestoneDigitalTask.Helpers
{
    public class BaseException : Exception
    {
        public HttpStatusCodeResult result;
        private HttpStatusCode errorCode { get; set; }
        private string errorMessage { get; set; }

        public BaseException() : base() { }

        public BaseException(Enums.Errors messege)
        {
            switch (messege)
            {
                case Enums.Errors.UserNotAuthorized:
                    errorCode = HttpStatusCode.Unauthorized;
                    errorMessage = Enums.Errors.UserNotAuthorized.GetLocalizedDescription();
                    break;
                case Enums.Errors.UserNotExist:
                    errorCode = HttpStatusCode.Unauthorized;
                    errorMessage = Enums.Errors.UserNotExist.GetLocalizedDescription();
                    break;
                case Enums.Errors.UserNotRegister:
                    errorCode = HttpStatusCode.Unauthorized;
                    errorMessage = Enums.Errors.UserNotRegister.GetLocalizedDescription();
                    break;
                case Enums.Errors.NotConfirm:
                    errorCode = HttpStatusCode.Unauthorized;
                    errorMessage = Enums.Errors.NotConfirm.GetLocalizedDescription();
                    break;
                case Enums.Errors.UserExist:
                    errorCode = HttpStatusCode.Unauthorized;
                    errorMessage = Enums.Errors.UserExist.GetLocalizedDescription();
                    break;
                case Enums.Errors.EmptyData:
                    errorCode = HttpStatusCode.NoContent;
                    errorMessage = Enums.Errors.EmptyData.GetLocalizedDescription();
                    break;
                case Enums.Errors.IncorrectEmailOrPassword:
                    errorCode = HttpStatusCode.Unauthorized;
                    errorMessage = Enums.Errors.IncorrectEmailOrPassword.GetLocalizedDescription();
                    break;
                case Enums.Errors.PasswordNotMatch:
                    errorCode = HttpStatusCode.Unauthorized;
                    errorMessage = Enums.Errors.PasswordNotMatch.GetLocalizedDescription();
                    break;
                case Enums.Errors.DataNotFound:
                    errorCode = HttpStatusCode.NotFound;
                    errorMessage = Enums.Errors.DataNotFound.GetLocalizedDescription();
                    break;
                case Enums.Errors.InternalServerError:
                    errorCode = HttpStatusCode.InternalServerError;
                    errorMessage = Enums.Errors.InternalServerError.GetLocalizedDescription();
                    break;
                case Enums.Errors.AccessIsDenied:
                    errorCode = HttpStatusCode.Forbidden;
                    errorMessage = Enums.Errors.AccessIsDenied.GetLocalizedDescription();
                    break;
                case Enums.Errors.Redirect:
                    errorCode = HttpStatusCode.Redirect;
                    errorMessage = Enums.Errors.Redirect.GetLocalizedDescription();
                    break;
                case Enums.Errors.ServerIgnor:
                    errorCode = HttpStatusCode.ServiceUnavailable;
                    errorMessage = Enums.Errors.ServerIgnor.GetLocalizedDescription();
                    break;
                case Enums.Errors.UploudFilesError:
                    errorCode = HttpStatusCode.BadRequest;
                    errorMessage = Enums.Errors.UploudFilesError.GetLocalizedDescription();
                    break;
                case Enums.Errors.InvalidToken:
                    errorCode = HttpStatusCode.Unauthorized;
                    errorMessage = Enums.Errors.InvalidToken.GetLocalizedDescription();
                    break;
                case Enums.Errors.UserBlocked:
                    errorCode = HttpStatusCode.Forbidden;
                    errorMessage = Enums.Errors.UserBlocked.GetLocalizedDescription();
                    break;
                default:
                    errorCode = HttpStatusCode.BadRequest;
                    errorMessage = Enums.Errors.SomethingWentWrong.GetLocalizedDescription();
                    break;
            }

            result = new HttpStatusCodeResult(errorCode, errorMessage);
        }
    }
}