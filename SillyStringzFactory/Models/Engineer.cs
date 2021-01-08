using System.Collections.Generic;

namespace SillyStringzFactory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.JoinEntries = new HashSet<EngineerMachine>();
    }

    public int EngineerId { get; set; }
    public string Name { get; set; }
    public bool Assigned { get; set; } 

    public virtual ICollection<EngineerMachine> JoinEntries { get; set; }
  }
}