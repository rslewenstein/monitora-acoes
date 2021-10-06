using System;
using Monitora_Acoes.Crawler;
using System.IO;
using System.Collections.Generic;
using System.Net;
using Monitora_Acoes.Bot.Interfaces;

namespace Monitora_Acoes.Bot
{
    public class BotSendMessage : IBotSendMessage
    {
        private readonly IBotProcess _botProc;
        public BotSendMessage(IBotProcess botProc)
        {
            _botProc = botProc;
        }
        public void SendMessageTelegram(string token)
        {
            string apiToken = token;
            string chatId = _botProc.GetChatId();
            List<string> stocks = _botProc.ProcessMessage();

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