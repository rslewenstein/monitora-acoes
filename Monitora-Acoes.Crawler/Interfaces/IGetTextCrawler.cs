using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitora_Acoes.Crawler.Interfaces
{
    public interface IGetTextCrawler
    {
        string Execute(string stocks);
    }
}