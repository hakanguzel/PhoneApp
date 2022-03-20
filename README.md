# PhoneApp

Basit bir telefon rehberi uygulamasıdır. Microservis yapısıdr.
![Mimari](https://github.com/hakanguzel/PhoneApp/blob/main/files/diagram.png)

    
## API Kullanımı

#### Servis Adresi

```http
http://localhost:5000/
```

#### Tüm kişileri getir

```http
  GET /userservice/users
```

#### Kişi detay getir

```http
  GET /userservice/users/{id}
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Gerekli**. Çağrılacak kişinin id değeri |

#### Kişi Kaydet

```http
  POST /userservice/users
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `name`      | `string` | **Gerekli**. Oluşturulacak kişinin ad değeri |
| `surname`      | `string` | **Gerekli**. Oluşturulacak kişinin soyad değeri |
| `companyName`      | `string` | **Gerekli**. Oluşturulacak kişinin firma değeri |

#### Kişi Sil

```http
  DELETE /userservice/users/{id}
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Gerekli**. Silinecek kişinin id değeri |

#### Kişiye İletişim Bilgisi Ekle

```http
  POST /userservice/users/contact/{id}
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Gerekli**. Oluşturulacak iletişim bilgisinin ait olduğu kişinin id değeri |
| `informationType`      | `string` | **Gerekli**. Silinecek kişinin id değeri(phone, email, address) |
| `content`      | `string` | **Gerekli**. Silinecek kişinin id değeri |

#### İletişim Bilgisi Sil

```http
  DELETE /userservice/users/contact/{id}
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Gerekli**. Silinecek iletişim bilgisinin id değeri |

  
#### Tüm raporları getir

```http
  GET /reportservice/reports
```

#### Rapor detayı getir

```http
  GET /reportservice/reports/{id}
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Gerekli**. Çağrılacak raporun id değeri |

#### Rapor Talebi Oluştur

```http
  POST /reportservice/reports
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `location`      | `string` | **Gerekli**. Raporun oluşturulacağı lokasyon bilgisi |

#### Consumer tarafından talebin oluşturulması için istek yapılacak endpoint

```http
  POST /reportservice/generate
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `reportId`      | `int` | **Gerekli**. Oluşturulacak raporun id değeri | 

## Bilgisayarınızda Çalıştırın

Projeyi klonlayın

```bash
  git clone https://github.com/hakanguzel/PhoneApp
```

Proje dizinine gidin

```bash
  cd PhoneApp
```

Gerekli paketleri yükleyin

```bash
  dotnet restore
```

Projelerin konfiguresyonunu düzeltin

**PhoneApp.Consumer.Report** appsettings.{EnvironmentName}.json

**PhoneApp.ReportService.API** appsettings.{EnvironmentName}.json

**PhoneApp.UserService.API** appsettings.{EnvironmentName}.json

**Migration**

```bash
add-migration [MigrationName] -StartUpProject PhoneApp.UserService.API -project PhoneApp.Core.Infrastructure -v
update-database -StartUpProject PhoneApp.UserService.API -project PhoneApp.Core.Infrastructure -v
```

Projeyi çalıştırın

```bash
  dotnet run
```
## Testler

Testleri çalıştırmak için aşağıdaki komutu çalıştırın

```bash
  dotnet test
```

  
## Kullanılan Teknolojiler

[.NET 6](https://github.com/microsoft/dotnet)

[DDD Design Pattern](https://docs.microsoft.com/tr-tr/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)

[CQRS Design Pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)

[MediatR](https://github.com/jbogard/MediatR)

[RabbitMQ](https://github.com/rabbitmq/rabbitmq-server)

[MsSQL](https://www.microsoft.com/tr-tr/sql-server/sql-server-2019)

[Entity Framework](https://github.com/dotnet/EntityFramework.Docs)

[Ocelot](https://github.com/ThreeMammals/Ocelot)

[.Net CAP](https://github.com/dotnetcore/CAP)

[Swagger](https://github.com/swagger-api/swagger-ui)

[MoqAssist](https://github.com/omeerkorkmazz/MoqAssist)

  
## Özellikler

- Kişi oluşturma
- Kişi kaldırma
- Kişiye iletişim bilgisi ekleme
- Kişiden iletişim bilgisi kaldırma
- Kişilerin listelenmesi
- Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detayların listelenmesi
- Rehberdeki kişilerin bulundukları konuma göre istatistiklerini çıkartan bir rapor talebi
- Sistemin oluşturduğu raporların listelenmesi
- Sistemin oluşturduğu bir raporun detay bilgilerinin getirilmesi
  
## Yol haritası

- Ocelot'a swagger desteği

- Proje'nin Dockerize edilmesi

- Listelerde pagination yapısı

- API'den gelen string haldeki enum değerlerden olmayanlar için anlamlı Exception gönderilmesi
  
## Yazarlar

- [@hakanguzel](https://www.github.com/hakanguzel) geliştirme

  
