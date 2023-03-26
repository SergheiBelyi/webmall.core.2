using System;

namespace ValmiStore.Model.Entities.MarketingActions
{
    public class MarketingAction
    {
        public string ActionId { get; set; }
        public string ActionName { get; set; }
        public string  ActionType { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Comment { get; set; }
        public string Banner { get; set; }
        public MarketingActionStatus ActionStatus { get; set; }
        public string ActionStatusName { get; set; }


        public enum MarketingActionStatus
        {
            ActiveAction,
            ActionFinished,
            ActionBonusesAvailable
        }

        public enum MarketingActionType
        {
            LoyaltyProgram = 0, 
            Cumulative = 1
        }

        public static string[] MarketingActionTypeNames = { "Программа лояльности", "Накопительная" };

        public class ActionPresent
        {
            public string Present { get; set; }
            public int Price { get; set; }
            public bool Available { get; set; }
        }
    }
}
