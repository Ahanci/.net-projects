# C# Class ve Interface Miras Kuralları

## 1️⃣ Sıralama Kuralı

C#'ta bir sınıfın miras aldığı diğer türleri belirtirken `:` işareti kullanılır. Sıralama şöyle olmalıdır:

```csharp
class DerivedClass : BaseClass, IInterface1, IInterface2, ...
```

* **İlk**: Sadece bir **class** olabilir (BaseClass)
* **Sonrakiler**: Sınırsız sayıda **interface** olabilir (IInterface1, IInterface2...)

---

## 2️⃣ Örnek

```csharp
class Animal { }

interface IFly
{
    void Fly();
}

interface ISing
{
    void Sing();
}

class Crow : Animal, IFly, ISing
{
    public void Fly()
    {
        Console.WriteLine("Crow is flying");
    }

    public void Sing()
    {
        Console.WriteLine("Crow is singing");
    }
}
```

✅ Geçerli çünkü:

* `Animal` → bir **class**, en başta
* `IFly`, `ISing` → **interface’ler**, sonrasında listeleniyor

---

## 3️⃣ Geçersiz Örnek

```csharp
class Crow : IFly, Animal  // ❌ Hatalı!
{
}
```

* Hatalı çünkü **class (Animal)** en başta yazılmalıdır.
* Derleyici hatası: "Class type 'Animal' must come before any interfaces"

---

## 4️⃣ Özet

* `:` işaretinden sonra **sadece bir class** yazabilirsin, o da **ilk sırada olmak zorunda**.
* Geri kalanlar **interface** olmalı.
* Bu, C#'ta **multiple inheritance** (birden fazla class’tan miras) sorunlarını önlemek için gereklidir.
