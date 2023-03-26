using System.Web.Mvc;
using Webmall.Model.Entities.User;
using Webmall.UI.ViewModel.Common;

namespace Webmall.UI.Service.Interfaces
{
    public interface IUserRegistration
    {
        void Validate(Controller context, UserRegistrationData user);

        MessageViewModel RegisterNewUser(Controller context, UserRegistrationData user, string representationFlag);

        void InitializeRegistrationReferences(Controller context);
    }
}