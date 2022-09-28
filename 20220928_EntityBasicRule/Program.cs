using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

Console.WriteLine();

#region Veri Nasıl Eklenir?
//ETicaretContext context = new();
//Urun urun = new()
//{
//    UrunAdi = "A Ürünü",
//    Fiyat = 1000
//};

#region context.AddAsync Fonksiyonu 
//Ürün ekleme talimatı
//await context.AddAsync(urun);
#endregion
#region context.DbSet.AddAsync Fonksiyonu
//Tip güvenli olarak veri ekleme yapılmaktadır.

//await context.Urunler.AddAsync(urun);
#endregion



#endregion
#region SaveChanges Nedir?
//await context.SaveChangesAsync(); 

//SaveChanges; insert, update ve delete sorgularını oluşturup bir transaction eşliğinde veritabanına gönderip execute eden fonksiyodur.
//Eğer ki oluşturulan sorgulardan herhangi biri başarısız olursa tüm işlemleri geri alır(rollback)
#endregion
#region EF Core Açısından Bir Verinin Eklenmesi Gerektiği Nasıl Anlaşılıyor?
//Yapılan işlemin Insert, Update veya delete olduğu nasıl anlaşılmaktadır?

//ETicaretContext context = new();
//Urun urun = new()
//{
//    UrunAdi = "B ürünü",
//    Fiyat = 2000
//};


//Console.WriteLine(context.Entry(urun).State );

//await context.AddAsync(urun);

//Console.WriteLine(context.Entry(urun).State);

//await context.SaveChangesAsync();

//Console.WriteLine(context.Entry(urun).State);
#endregion
#region Birden Fazla Veri Eklerken Nelere Dikkat Edilmelidir?
#region SaveChanges'ı Verimli Kullanalım!
//SaveChanges fonksiyonu her tetiklendiğinde bir transaction oluşturacağından dolayı EF Core ile yapılan her bir işleme özel kullanmaktan kaçınmalıyız!
//Çünkü her işleme özel transaction veritaanı açısından ekstradan maliyet demektir.
//O yüzden mümkün mertebe tüm işlemlerimizi tek bir transaction eşliğinde veritabanına gönderebilmek için savechanges'ı aşağıdaki gibi tek seferde kullanmak hem maliyet hem de yönetilebilirlik açısından katkıda bulunmuş olacaktır.

//ETicaretContext context = new();
//Urun urun1 = new()
//{
//    UrunAdi = "C ürünü",
//    Fiyat = 2000
//};
//Urun urun2 = new()
//{
//    UrunAdi = "D ürünü",
//    Fiyat = 2000
//};
//Urun urun3 = new()
//{
//    UrunAdi = "E ürünü",
//    Fiyat = 2000
//};

//await context.AddAsync(urun1);

//await context.AddAsync(urun2);

//await context.AddAsync(urun3);
//await context.SaveChangesAsync();
#endregion
#region AddRange
//ETicaretContext context = new();
//Urun urun1 = new()
//{
//    UrunAdi = "C ürünü",
//    Fiyat = 2000
//};
//Urun urun2 = new()
//{
//    UrunAdi = "D ürünü",
//    Fiyat = 2000
//};
//Urun urun3 = new()
//{
//    UrunAdi = "E ürünü",
//    Fiyat = 2000
//};
//await context.Urunler.AddRangeAsync(urun1, urun2, urun3);
//await context.SaveChangesAsync();
#endregion
#endregion
#region Eklenen Verinin Generate Edilen Id'sini Elde Etme
ETicaretContext context = new();
Urun urun = new()
{
    UrunAdi = "O ürünü",
    Fiyat = 2000
};
await context.AddAsync(urun);
await context.SaveChangesAsync();
Console.WriteLine(urun.Id);
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

#region OnConfiguring İle Konfigürasyon Ayarlarını Gerçekleştirmek
//EF Core tool'unu yapılandırmak için kullandığımız bir metottur.
//Context nesnesinde override edilerek kullanılmaktadır.
#endregion
#region Basit Düzeyde Entity Tanımlama Kuralları
//EF Core, her tablonun default olarak bir primary key kolonu olması gerektiğini kabul eder!
//Haliyle, bu kolonu temsil eden bir property tanımlamadığımız taktirde hata verecektir!
#endregion
#region Tablo Adını Belirleme

#endregion