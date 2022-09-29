
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

#region Veri Nasıl Güncellenir?
//ETicaretContext context = new();

//Urun urun= await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
//urun.UrunAdi = "Yastık";
//urun.Fiyat = 250;

//await context.SaveChangesAsync();


#endregion
#region ChangeTracker Nedir?
//ChangeTracker Context üzerinden gelen verilerin takibinden sorumlu bir mekanizmadır.
//Bu takip mekanizması sayesinde context üzerinden gelen verilerle ilgili işlemler neticesinde Update veya Deleted sorgularının oluşturulacağı anlaşılır.
#endregion
#region Takip Edilmeyen Nesneler Nasıl Güncellenir?
//ETicaretContext context = new();
//Urun urun = new()
//{
//    Id = 3,
//    UrunAdi = "Yeni Ürün",
//    Fiyat=123
//};

#endregion
#region Update Fonksiyonu
//ChangeTracker mekanizması tarafından takip edilmeyen nesnelerin güncellenebilmesi için Update fonksiyonu kullanılır.!
//Update fonksiyonunu kullanbilmek için kesinlikle ilgili nesnede ID değeri verilmelidir! 
//Bu değer güncellenecek(Update sorgusu oluşturulacak) verinin hangisi olduğunu ifade edecektir.

//context.Urunler.Update(urun);
//await context.SaveChangesAsync();
#endregion
#region EntityState Nedir?
//Bir Entity instance'nın durumunu ifade eden bir referanstır.

//ETicaretContext context = new();
//Urun urun = new();
//Console.WriteLine(context.Entry(urun).State);
#endregion
#region EF Core açısından bir verinin güncellenmesi gerektiği nasıl anlaşılıyor?
//ETicaretContext context = new();
//Urun urun=await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);

//Console.WriteLine(context.Entry(urun).State);

//urun.UrunAdi = "Hilmi";

//Console.WriteLine(context.Entry(urun).State);

//await context.SaveChangesAsync();

//Console.WriteLine(context.Entry(urun).State);
#endregion
#region Birden fazla veri güncellenirken nelere dikkat edilmelidir?
ETicaretContext context = new();
var urunler = await context.Urunler.ToListAsync();
foreach (var urun in urunler)
{
    urun.UrunAdi += "*";
    // await context.SaveChangesAsync();
    //Bu durumda sürekli olarak trancastion işlemi yapılacaktır.
}
await context.SaveChangesAsync();
//Tek seferde Transaction işlemi yapılır.
#endregion

public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = ASUS; Database = ECommerceDb; Trusted_Connection = True");

    }
}
public class Urun
{
    //public int Id { get; set; }
    //public int ID { get; set; }
    //public int UrunId { get; set; }
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }

}