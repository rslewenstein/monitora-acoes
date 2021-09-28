using System;
using Monitora_Acoes.Crawler;
using System.IO;
using System.Collections.Generic;
using System.Net;

namespace Monitora_Acoes.Bot
{
    public class BotSendMessage
    {
        public void SendMessageTelegram(string token)
        {
            string apiToken = token;
            var botProc = new BotProcess();
            string chatId = botProc.GetChatId();
            List<string> stocks = botProc.ProcessMessage(chatId);

            foreach (var stock in stocks)
            {
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                urlString = String.Format(urlString, apiToken, chatId, stock);
                WebRequest request = WebRequest.Create(urlString);
                Stream rs = request.GetResponse().GetResponseStream();
            }
        }
    }
}