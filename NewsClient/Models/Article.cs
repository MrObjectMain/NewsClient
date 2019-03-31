using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsClient.Models
{
    public class Article : BaseEntity
    {
        public string SourceId { get; set; }
        [ForeignKey("SourceId")]
        public Source Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime? PublishedAt { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}\r\n Author: {Author}\r\n Url: {Url}\r\n UrlToImage: {UrlToImage}\r\n PublishedAt: {PublishedAt}\r\n Description: {Description}\r\n Source: {Source}\r\n";
        }
    }
}
