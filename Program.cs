using DotnetStore;
using System;
using System.Diagnostics;
using System.Reflection;

List<Products> p = new List<Products>
{
    new Products() { SKU = "SK1", Name = "pulpen", Stock = 100, Price = 2000 },
    new Products() { SKU = "SK2", Name = "lemari", Stock = 56, Price = 50000 }
};

List<Cart> c = new List<Cart> 
{
    new Cart() { SKU = "SK1", Name = "pulpen", Quantity = 1, Price = 2000},
    new Cart() { SKU = "SK2", Name = "lemari", Quantity = 1, Price = 50000}
};

void Display()
{
    Console.WriteLine("===================================");
    Console.WriteLine("\t \t Menu");
    Console.WriteLine("===================================");
    Console.WriteLine("\t 1. Tambah Produk");
    Console.WriteLine("\t 2. Edit Produk");
    Console.WriteLine("\t 3. Tampilkan Produk");
    Console.WriteLine("\t 4. Hapus Produk");
    Console.WriteLine("\t 5. Add Produk ke Cart");
    Console.WriteLine("\t 6. Hapus Produk dari Cart");
    Console.WriteLine("\t 7. Tampilkan Cart");
    Console.WriteLine("\t 8. Checkout");
    Console.WriteLine("\t 9. Keluar");
}

void ShowProduct()
{
    Console.WriteLine("=======================================================================");
    Console.WriteLine("Nomor \t SKU \t Name\t       Stock \t Price");
    Console.WriteLine("=======================================================================");
    int index = 1;
    foreach (var item in p)
    {
        Console.WriteLine($" {index++} \t {item.SKU} \t {item.Name}\t\t{item.Stock} \t {item.Price}");
    }
}

void AddProduct()
{
    Console.WriteLine("\t Menu Tambah produk");
    Console.WriteLine("\nMasukan Produk yang ingin di tambah");
    Console.Write("SKU \t : ");
    var sku = Console.ReadLine().ToUpper();
    Console.Write("Nama \t : ");
    var nama = Console.ReadLine();
    Console.Write("Stock \t : ");
    int stock = Convert.ToInt32(Console.ReadLine());
    Console.Write("Price \t : ");
    int price = Convert.ToInt32(Console.ReadLine());


    p.Add(new Products() { SKU = sku, Name = nama, Stock = stock, Price = price });
    Console.WriteLine("\nProduk berhasil di tambahkan");
}

void EditProduct()
{
    Console.Write("\nMasukan nomor produk yang ingin kamu edit : ");
    var numProducts = Convert.ToInt32(Console.ReadLine());
    var index = numProducts - 1;
    Console.WriteLine("\nsilahkan edit");
    Console.Write("\nSKU \t : ");
    var sku = Console.ReadLine();
    Console.Write("Nama \t : ");
    var nama = Console.ReadLine();
    Console.Write("Stock \t : ");
    int stock = Convert.ToInt32(Console.ReadLine());
    Console.Write("Price \t : ");
    int price = Convert.ToInt32(Console.ReadLine());
    p.RemoveAt(index);
    p.Insert(index, new Products() { SKU = sku, Name = nama, Stock = stock, Price = price });
}

void RemoveProduct()
{
    Console.Write("\nMasukan nomor yang ingin kamu hapus : ");
    var numProduct = Convert.ToInt32(Console.ReadLine());
    var index = numProduct - 1;
    p.RemoveAt(index);
    Console.WriteLine("\nProduk telah terhapus");
}

void AddProductToCart()
{
    Console.Write("\nMasukan kode SKU produk yang anda ingin tambahkan : ");
    var inputUser = Console.ReadLine().ToUpper();
    Console.Write("Masukan nomor produknya : ");
    var numProduct = Convert.ToInt32(Console.ReadLine());
    var index = numProduct - 1;
    var dataProduct = p.Find(p => p.SKU == inputUser);
    var skuCart = dataProduct.SKU;
    var nameCart = dataProduct.Name;
    var quantity = 1;
    var priceCart = dataProduct.Price;

    p.RemoveAt(index);
    p.Insert(index, new Products() { SKU = skuCart, Name = nameCart, Stock = dataProduct.Stock - 1, Price = priceCart });

    c.Add(new Cart() { SKU = skuCart, Name = nameCart, Quantity = quantity, Price = priceCart });

}

void ShowCart()
{
    Console.WriteLine("=======================================================================");
    Console.WriteLine("Nomor \t SKU \t Name\t     Quantity \t Price");
    Console.WriteLine("=======================================================================");
    int index = 1;
    foreach (var item in c)
    {
        Console.WriteLine($" {index++} \t {item.SKU} \t {item.Name}\t\t{item.Quantity} \t {item.Price}");
    }
}

void RemoveCart()
{
    Console.Write("\nMasukan nomor yang ingin kamu hapus : ");
    var numProduct = Convert.ToInt32(Console.ReadLine());
    var index = numProduct - 1;
    c.RemoveAt(index);
}

void Checkout()
{
    var totalPrice = 0;

    foreach (var item in c)
    {
        totalPrice += item.Price;
    }
    Console.WriteLine($"\nTotal Bayar : {totalPrice}");
}

//program akan di ulang terus dengan nilai true
while (true)
{
    Console.Clear();

    // memanggil method display tampilan
    Display();
    Console.WriteLine("===================================");
    Console.Write("Masukan pilihan : ");
    var pilihan = Console.ReadLine();
    switch(pilihan)
    {
        case "1":
            Console.Clear();

            // menu menambah produk
            AddProduct();

            Console.ReadLine();
            break;
        case "2":
            Console.Clear();
            Console.WriteLine("\t\t Menu Edit Produk");
            Console.WriteLine("\t\t  Daftar Produk");

            // menampilkan produk yang tersedia sebelumnya
            ShowProduct();

            // menu edit produk
            EditProduct();

            // menampilkan produk yang sudah di edit
            Console.WriteLine("\n \t\tDaftar Produk Update");
            ShowProduct();

            Console.WriteLine("\nProduk berhasil di edit");
            Console.ReadLine();
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("\t\t Menu Tampilkan Semua Produk");
            Console.WriteLine("\t\t        Daftar Produk");

            // menampilkan daftar produk tersedia
            ShowProduct();
            Console.ReadLine();
            break;
        case "4":
            Console.Clear();
            Console.WriteLine("\t\t Menu Hapus Produk");
            Console.WriteLine("\t\t   Daftar Produk");

            // menampilkan produk yang tersedia untuk memudahkan memberi informasi tengtang produk yang ingin dihapus
            ShowProduct();
            // menghapus produk dengan index
            RemoveProduct();
            Console.ReadLine();
            break;
        case "5":
            Console.Clear();
            Console.WriteLine("\t\tMenu Add to Cart");
            Console.WriteLine("\t\t Daftar produk");

            // menampilkan informasi produk agar memudahkan costumer dalam melihat informasi produk
            ShowProduct();
            Console.WriteLine("=======================================================================");

            // costumer memasukan kode SKU produk yang ingin di tambahkan ke keranjang
            AddProductToCart();

            // menampilkan daftar cart agar dapat melihat produk yang telah di tambahkan ke dalam cart
            Console.WriteLine("\n\t\t Daftar Cart");
            ShowCart();
            Console.WriteLine("\nProduk telah ditambahkan ke Cart");
            Console.ReadLine();
            break;
        case "6":
            Console.Clear();
            Console.WriteLine("\t\tMenu Hapus Produk dari Cart");
            ShowCart();
            RemoveCart();
            Console.WriteLine("\nProduk telah terhapus");
            Console.ReadLine();
            break;
        case "7":
            Console.Clear();
            Console.WriteLine("\t\tMenu Tampilkan semua Cart");
            Console.WriteLine("\t\t       Daftar Cart");
            ShowCart();
            Console.ReadLine();
            break;
        case "8":
            Console.Clear();
            Console.WriteLine("\t Menu Checkout\n");
            Console.WriteLine("1. Bayar");
            Console.WriteLine("2. Cancel ");
            Console.Write("\nMasukan pilihan : ");
            var menuCheckout = Console.ReadLine();
            switch (menuCheckout)
            {
                case "1":
                    Console.Clear();
                    ShowCart();
                    Checkout();
                    break;
                case "2":
                    Console.WriteLine("Tekan enter");
                    break;
            }
            Console.ReadLine();
            break;
        case "9":
            Environment.Exit(0);
            break;
    }
};