namespace Webmall.Model.Entities.Cms
{
    public class MailMessageTemplate
    {
        public string Slug { get; set; }
        public string Receivers { get; set; }
        public string Text { get; set; }
    }

    public enum MailMessages
    {
        RegistrationConfirmationRequest,
        MsgPasswordRecovery,
        MsgRequestByVin,
        MsgUserMessage,
        MsgRepresenterRegistrationRequest,
        MsgRegistrationComplete,
        MsgAcceptRegistrationSucces,
        MsgAcceptRegistrationFail,
        MsgRepresentationRequestError,
        MsgServiceBookingRequest,
        MsgPromotionSubscriptionMessage,
        MsgJuridicalRegistrationInfoMessage,
        MsgPhisicalRegistrationInfoMessage,
        MsgRepresentationRequestConfirmationMessage
    }
}
