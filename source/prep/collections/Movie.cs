using System;

namespace prep.collections
{
  public class Movie
  {
      protected bool Equals(Movie other)
      {
          return string.Equals(title, other.title);
      }

      public override bool Equals(object obj)
      {
          if (ReferenceEquals(null, obj)) return false;
          if (ReferenceEquals(this, obj)) return true;
          if (obj.GetType() != this.GetType()) return false;
          return Equals((Movie) obj);
      }

      public override int GetHashCode()
      {
          return (title != null ? title.GetHashCode() : 0);
      }

    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }
    


  }
}