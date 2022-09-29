
using Microsoft.EntityFrameworkCore;


ETicaretContext context = new();

#region En Temel Basit Bir Sorgulama Nasıl Yapılır?
#region Method Syntax
//var urunler = await context.Urunlerim.ToListAsync();
#endregion
#region Query Syntax
//var urunler2 = (from urun in context.Urunlerim
//                select urun).ToListAsync();
#endregion
#endregion
#region Sorguyu Execute Etmek için Ne yapmamız Gerekmektedir?
#region ToListAsync
#region Method Syntax
//var urunler =await context.Urunlerim.ToListAsync();
#endregion
#region Query Syntax
//var urunler2 = (from urun in context.Urunlerim
//              select urun).ToListAsync();
#endregion
#endregion
#region Foreach
//var urunler = from urun in context.Urunlerim
//              select urun;
//foreach (Urun urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//}
#endregion
#region Deferred Execution(Ertelenmiş Çalışma)
int urunId = 5;
var urunler = from urun in context.Urunlerim
              where urun.Id > urunId
              select urun;
urunId = 200;

foreach (Urun urun in urunler)
{
    Console.WriteLine(urun.UrunAdi);
}


//IQueryable çalışmalarında ilgili kod yazıldığı noktada tetiklenmez/çalıştırılmaz yani ilgili kod yazıldığı noktada sorguyu generate etmez!
//Çalıştırıldığı Execute edildiği noktada tetiklenir! 
//İşte bu duruma ertelenmiş çalışma denilmektedir.
//Yukarıdaki örnekte UrunId daha sonradan 200 değeri sorgudan daha sonra verilmesine rağmen,yukarıdaki sorgu execute edilmediği için 200 değerini almaktadır.
#endregion
#endregion
#region IQueryable ve IEnumerable Nedir? Basit Olarak!
//var urunler = (from urun in context.Urunlerim
//              select urun).ToListAsync();
//ToListAsync execute etmek maksadıyla kullanmaktadır.


#region IQueryable
//Sorguya karşılık gelir.
//EF Core üzerinden yapılmış olan sorgunun execute edilmemiş halini ifade eder.

#endregion
#region IEnumerable
//Sorgunun çalıştırılıp/Execute edilip verilerin in memory'e yüklenmiş halini ifade eder.

#endregion
#endregion
public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunlerim { get; set; }
    public DbSet<Parca> Parcalar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = ASUS; Database = ECommerceDb; Trusted_Connection = True");
    }
}
public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }
    public ICollection<Parca> Parcalar { get; set; }

}
public class Parca
{
    public int Id { get; set; }
    public string ParcaAdi { get; set; }
}

