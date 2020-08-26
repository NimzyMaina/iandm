using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IandMApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public User()
        {
            IoUs = new Collection<IoU>();
            UoMes = new Collection<IoU>();
        }
        
        // Navigation properties
        public ICollection<IoU> IoUs { get; set; }
        public ICollection<IoU> UoMes { get; set; }
        
        
    }
}