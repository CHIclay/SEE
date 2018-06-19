using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    internal class AttentionMetaData
    {
        [Key]
        public int Att_ID { get; set; }    
    }
    [MetadataType(typeof(AttentionMetaData))]
    public partial class Attention
    {
      
    }
}
