using System;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Quartz;

namespace Webmall.UI.Core.Jobs
{
    public class SubscribeProcessJob : IJob
    {
        #region Logger

        // ReSharper disable InconsistentNaming
        private static readonly ILog log = LogManager.GetLogger(typeof(SubscribeProcessJob));
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// Логер сервиса
        /// </summary>
        public static ILog Log
        {
            get { return log; }
        }

        static SubscribeProcessJob()
        {
            XmlConfigurator.Configure();
        }
        #endregion

        private static bool _isWorking;
        public async Task Execute(IJobExecutionContext context)
        {
            if (_isWorking)
                return;
            _isWorking = true;
            try
            {
                //    Log.Debug("SubscribeProcessJob Started");
                //    var cmsRepository = DependencyResolver.Current.GetService<ICmsRepository>();
                //    var learningRepository = DependencyResolver.Current.GetService<ILearningCenterRepository>();
                //    var trainings = cmsRepository.GetTrainings().Where(i => i.SendForSubscribers).ToList();
                //    Log.DebugFormat("Training for send found: {0}", trainings.Count);
                //    Log.DebugFormat("Training subscribers found: {0}", learningRepository.GetTrainingSubscriptions().Count());
                //    foreach (var training in trainings)
                //    {
                //        Log.DebugFormat("Training processing: {0}", training.Title);
                //        cmsRepository.ResetTrainigSendForSubscribers(training.Id);
                //        Log.DebugFormat("Training {0} resetted", training.Title);
                //        foreach (var subscription in learningRepository.GetTrainingSubscriptions())
                //        {
                //            Log.DebugFormat("Sending training {0} for {1}", training.Title, subscription.Email);
                //            try
                //            {
                //                MailHelper.SendTrainingSubscriptionMessage(training, subscription);
                //                Log.DebugFormat("Training {0} for {1} sent successfully", training.Title, subscription.Email);
                //            }
                //            catch (Exception e)
                //            {
                //                Log.Error("SendTrainingSubscriptionMessage exception", e);
                //            }
                //        }
                //    }
                //    Log.DebugFormat("News block started");
                //    var userRepository = DependencyResolver.Current.GetService<IUserRepository>();

                //    foreach (var news in cmsRepository.GetNews().Where(i => i.SendForSubscribers))
                //    {
                //        cmsRepository.ResetNewsSendForSubscribersFlag(news.Id);
                //        foreach (var subscription in userRepository.GetUsers(new UserFilter()).Where(i => i.SubscribeForPromotions))
                //        {
                //            MailHelper.SendPromotionSubscriptionMessage(news, subscription, false);
                //            Log.DebugFormat("Sending news {0} for {1}", news.Header, subscription.Email);
                //        }
                //    }

                //    foreach (var news in cmsRepository.GetPromos(new string[0]).Where(i => i.SendForSubscribers))
                //    {
                //        cmsRepository.ResetPromoSendForSubscribersFlag(news.Id);
                //        foreach (var subscription in userRepository.GetUsers(new UserFilter()).Where(i => i.SubscribeForPromotions))
                //        {
                //            MailHelper.SendPromotionSubscriptionMessage(news, subscription, true);
                //            Log.DebugFormat("Sending promotion {0} for {1}", news.Header, subscription.Email);
                //        }
                //    }

                //    Log.Debug("SubscribeProcessJob Finished");
            }
            catch (Exception e)
            {
                Log.Error("SubscribeProcessJob exception", e);
            }
            finally
            {
                _isWorking = false;
            }
        }
    }
}