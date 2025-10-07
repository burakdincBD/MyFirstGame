# MyFirstGame
 Baby steps with Unity

# OTB COĞRAFİ BİLGİ SİSTEMİ (CBS) VE VERİ YÖNETİMİ DOKÜMANI

## 📋 GENEL BAKIŞ

Bu doküman, OTB (Organize Tarım Bölgeleri) projelerinde **Coğrafi Bilgi Sistemi (CBS)** kullanımı ve **Veri Yönetimi** süreçlerini detaylı olarak açıklamaktadır. 23.09.2025 toplantı notları ve proje gereksinimleri temel alınarak hazırlanmıştır.

---

## 🎯 CBS (COĞRAFİ BİLGİ SİSTEMİ) NEDİR?

**CBS (Coğrafi Bilgi Sistemi / Geographic Information System - GIS)**, coğrafi verilerin toplanması, depolanması, analiz edilmesi ve görselleştirilmesi için kullanılan bir sistemdir. OTB projelerinde parseller, altyapı, üretim ve yönetim bilgilerinin harita üzerinde gösterilmesi ve takibi için kullanılır.

### 23.09.2025 Toplantı Notlarından CBS Gereksinimleri:

- **YENİ:** Coğrafya Bilgi Sistemi Haritalar Bize Özel mi olacak?
  → Evet, OTB'ye özel CBS harita sistemi gerekli

- **YENİ:** Tapusu verildi verilmedi ayrımı parselizasyonda renk ayrımı
  → 🟢 Yeşil: Tapu verildi
  → 🔴 Kırmızı: Tapu verilmedi

- **YENİ:** OTB'den İstenilen Bilgiler:
  → Parsel Sahibi
  → Üretilen Ürün
  → Personel Sayısı

---

## 📊 1. CBS HARITA SİSTEMİ GENEL YAPISI

```mermaid
graph TD
    Start[OTB CBS Sistemi] --> Layers[Harita Katmanları]

    Layers --> Layer1[Katman 1: Temel Harita<br/>OpenStreetMap/Google Maps]
    Layers --> Layer2[Katman 2: Parsel Sınırları]
    Layers --> Layer3[Katman 3: Altyapı<br/>Yol, Su, Elektrik]
    Layers --> Layer4[Katman 4: Yapılar<br/>Sera, Tesis, Bina]
    Layers --> Layer5[Katman 5: Veri Katmanı<br/>Parsel Bilgileri]

    Layer2 --> ParcelData[Parsel Verileri]
    ParcelData --> PD1[Parsel No]
    ParcelData --> PD2[Alan m²]
    ParcelData --> PD3[Koordinatlar]
    ParcelData --> PD4[Kategori]

    Layer5 --> OwnerInfo[YENİ: Parsel Sahibi]
    Layer5 --> ProductInfo[YENİ: Üretilen Ürün]
    Layer5 --> PersonnelInfo[YENİ: Personel Sayısı]
    Layer5 --> DeedStatus[YENİ: Tapu Durumu]
    Layer5 --> CreditType[Kredi Tipi]

    DeedStatus --> ColorCoding[Renk Kodlama]
    ColorCoding --> Green[🟢 Yeşil:<br/>Tapu Verildi]
    ColorCoding --> Red[🔴 Kırmızı:<br/>Tapu Verilmedi]
    ColorCoding --> Yellow[🟡 Sarı:<br/>Tapu İşlemde]

    CreditType --> Blue[🔵 Mavi:<br/>Bakanlık Kredili]
    CreditType --> GreenCredit[🟢 Yeşil:<br/>Kredisiz]

    OwnerInfo --> Popup[Parsel Pop-up Bilgi]
    ProductInfo --> Popup
    PersonnelInfo --> Popup
    DeedStatus --> Popup
    CreditType --> Popup

    Popup --> UserInteraction[Kullanıcı Etkileşimi:<br/>- Tıklama<br/>- Filtre<br/>- Arama<br/>- Rapor]

    style ColorCoding fill:#fff9e6
    style Green fill:#28a745,color:#fff
    style Red fill:#dc3545,color:#fff
    style Yellow fill:#ffc107,color:#000
    style Blue fill:#007bff,color:#fff
```

---

## 📊 2. PARSEL CBS VERİ YAPISI

```mermaid
graph TD
    Start[Parsel CBS Verisi] --> GeoData[Coğrafi Veri]
    Start --> AttrData[Öznitelik Verisi]

    GeoData --> Geometry[Geometri Tipi:<br/>Polygon]
    Geometry --> Coordinates[Koordinatlar<br/>WGS84 / EPSG:4326]
    Coordinates --> Points[Nokta Listesi:<br/>Köşe Koordinatları]

    Points --> Point1[Köşe 1: Lat, Lon]
    Points --> Point2[Köşe 2: Lat, Lon]
    Points --> Point3[Köşe 3: Lat, Lon]
    Points --> Point4[Köşe 4: Lat, Lon]
    Points --> PointN[...]

    AttrData --> BasicInfo[Temel Bilgiler]
    AttrData --> OwnerInfo[Sahiplik Bilgileri]
    AttrData --> ProductionInfo[Üretim Bilgileri]
    AttrData --> LegalInfo[Yasal Bilgiler]
    AttrData --> FinancialInfo[Finansal Bilgiler]

    BasicInfo --> BI1[Parsel No]
    BasicInfo --> BI2[Ada No]
    BasicInfo --> BI3[Parsel Alanı m²]
    BasicInfo --> BI4[Parsel Alanı Dekar]
    BasicInfo --> BI5[Kategori]

    BI5 --> Cat1[Hayvansal Üretim]
    BI5 --> Cat2[Bitkisel Üretim]
    BI5 --> Cat3[Su Ürünleri]
    BI5 --> Cat4[Sanayi]

    OwnerInfo --> OI1[YENİ: Parsel Sahibi Ad Soyad]
    OwnerInfo --> OI2[TC/Vergi No]
    OwnerInfo --> OI3[İletişim Bilgileri]
    OwnerInfo --> OI4[Tahsis Tarihi]

    ProductionInfo --> PI1[YENİ: Üretilen Ürün]
    ProductionInfo --> PI2[Üretim Kapasitesi]
    ProductionInfo --> PI3[Üretim Miktarı]
    ProductionInfo --> PI4[YENİ: Personel Sayısı]
    ProductionInfo --> PI5[Kadın Personel]
    ProductionInfo --> PI6[Erkek Personel]

    LegalInfo --> LI1[YENİ: Tapu Durumu]
    LegalInfo --> LI2[Tapu Tarihi]
    LegalInfo --> LI3[Tahsis Belgesi No]

    LI1 --> Deed1[🟢 Tapu Verildi]
    LI1 --> Deed2[🔴 Tapu Verilmedi]
    LI1 --> Deed3[🟡 Tapu İşlemde]

    FinancialInfo --> FI1[Kredi Tipi]
    FinancialInfo --> FI2[Kredi Tutarı]
    FinancialInfo --> FI3[Borç Durumu]
    FinancialInfo --> FI4[Ödeme Planı]

    FI1 --> Credit1[🔵 Bakanlık Kredisi - Proses A]
    FI1 --> Credit2[🟢 Kredisiz/Banka - Proses B]

    style Deed1 fill:#28a745,color:#fff
    style Deed2 fill:#dc3545,color:#fff
    style Deed3 fill:#ffc107,color:#000
    style Credit1 fill:#007bff,color:#fff
    style Credit2 fill:#28a745,color:#fff
```

---

## 📊 3. CBS RENK KODLAMA SİSTEMİ

```mermaid
graph TD
    Start[Parsel Renk Kodlama] --> DeedStatus{Tapu<br/>Durumu?}
    Start --> CreditStatus{Kredi<br/>Durumu?}

    DeedStatus -->|YENİ: Verildi| GreenDeed[🟢 YEŞİL PARSEL]
    DeedStatus -->|YENİ: Verilmedi| RedDeed[🔴 KIRMIZI PARSEL]
    DeedStatus -->|İşlemde| YellowDeed[🟡 SARI PARSEL]

    CreditStatus -->|Bakanlık Kredisi| BlueBorder[🔵 MAVİ ÇERÇEVE]
    CreditStatus -->|Kredisiz/Banka| GreenBorder[🟢 YEŞİL ÇERÇEVE]

    GreenDeed --> DeedGreenDetails[Yeşil Anlamı:<br/>✅ Tapu tescili tamamlandı<br/>✅ Tam mülkiyet<br/>✅ Tüm haklar sahibinde]

    RedDeed --> DeedRedDetails[Kırmızı Anlamı:<br/>⏳ Tapu başvurusu yapılmadı<br/>⏳ Sadece tahsis belgesi var<br/>⏳ Geçici kullanım]

    YellowDeed --> DeedYellowDetails[Sarı Anlamı:<br/>🔄 Tapu işlemleri devam ediyor<br/>🔄 Tapu müdürlüğünde<br/>🔄 Yakında tamamlanacak]

    BlueBorder --> CreditBlueDetails[Mavi Çerçeve Anlamı:<br/>💳 Bakanlık kredisi kullanıyor<br/>💳 Proses A<br/>💳 Mahsuplaşma gerekli]

    GreenBorder --> CreditGreenDetails[Yeşil Çerçeve Anlamı:<br/>✅ Kredisiz veya Banka kredisi<br/>✅ Proses B<br/>✅ Mahsuplaşma yok]

    DeedGreenDetails --> CombinationExample[Renk Kombinasyonları]
    DeedRedDetails --> CombinationExample
    DeedYellowDetails --> CombinationExample
    CreditBlueDetails --> CombinationExample
    CreditGreenDetails --> CombinationExample

    CombinationExample --> Combo1[🟢+🔵<br/>Tapu Var + Bakanlık Kredisi]
    CombinationExample --> Combo2[🟢+🟢<br/>Tapu Var + Kredisiz]
    CombinationExample --> Combo3[🔴+🔵<br/>Tapu Yok + Bakanlık Kredisi]
    CombinationExample --> Combo4[🔴+🟢<br/>Tapu Yok + Kredisiz]
    CombinationExample --> Combo5[🟡+🔵<br/>Tapu İşlemde + Bakanlık Kredisi]

    style GreenDeed fill:#28a745,color:#fff
    style RedDeed fill:#dc3545,color:#fff
    style YellowDeed fill:#ffc107,color:#000
    style BlueBorder fill:#007bff,color:#fff
    style GreenBorder fill:#28a745,color:#fff
```

---

## 📊 4. PARSEL POP-UP BİLGİ EKRANI

Kullanıcı harita üzerinde bir parsele tıkladığında açılan bilgi penceresi:

```
┌─────────────────────────────────────────────────────────────────┐
│                  PARSEL BİLGİ DETAYLARI                         │
│                   Parsel No: 12345                               │
└─────────────────────────────────────────────────────────────────┘

📍 KONUM BİLGİLERİ
─────────────────────────────────────────────────────────────────
Ada No                 : 101
Parsel No              : 12345
Alan (m²)              : 50,000 m²
Alan (Dekar)           : 5 dekar
Enlem (Latitude)       : 39.1234
Boylam (Longitude)     : 27.5678
Kategori               : 🌾 Bitkisel Üretim

👤 SAHİPLİK BİLGİLERİ (YENİ)
─────────────────────────────────────────────────────────────────
Parsel Sahibi          : [Ad Soyad / Şirket Adı]
TC/Vergi No            : [**********]
Telefon                : [0555 XXX XX XX]
E-posta                : [email@example.com]
Tahsis Tarihi          : [01/06/2024]

🏭 ÜRETİM BİLGİLERİ (YENİ)
─────────────────────────────────────────────────────────────────
Üretilen Ürün          : Domates (Sera)
Üretim Kapasitesi      : 225 ton/yıl (45 ton/dekar)
Mevcut Üretim          : 180 ton (Bu yıl)
Üretim Başlangıcı      : Ocak 2024

👥 PERSONEL BİLGİLERİ (YENİ)
─────────────────────────────────────────────────────────────────
Toplam Personel        : 38 kişi
   ↳ Kadın             : 29 kişi (%76)
   ↳ Erkek             : 9 kişi (%24)
Mevsimlik Personel     : 15 kişi
Sürekli Personel       : 23 kişi

📋 YASAL DURUM
─────────────────────────────────────────────────────────────────
Tapu Durumu            : 🟢 Tapu Verildi
Tapu Tarihi            : 15/08/2024
Tapu No                : 12345/2024
Tahsis Belgesi No      : OTB-2024-12345

💳 FİNANSAL BİLGİLER
─────────────────────────────────────────────────────────────────
Kredi Tipi             : 🔵 Bakanlık Kredisi (Proses A)
Kredi Tutarı           : 2,500,000 TL
Kullanılan Kredi       : 2,500,000 TL
Kalan Borç             : 1,850,000 TL
Ödeme Durumu           : ✅ Düzenli
Sonraki Ödeme          : Aralık 2024 (Yıl Sonu)

📊 YATIRIM BİLGİLERİ
─────────────────────────────────────────────────────────────────
Toplam Yatırım         : 3,200,000 TL
Tamamlanma Oranı       : %100
Yatırım Tarihi         : Mart 2023 - Aralık 2023
Sera Tipi              : Jeotermal Isıtmalı Cam Sera
Sera Alanı             : 4,500 m²

🌍 YEŞİL OTB BİLGİLERİ
─────────────────────────────────────────────────────────────────
Enerji Kaynağı         : ♨️ Jeotermal
Enerji Tasarrufu       : %82
Su Tasarrufu           : %65 (Damla sulama)
Karbon Ayak İzi        : -45 ton CO2/yıl (Negatif)

📅 ÖNEM TARİHLERİ
─────────────────────────────────────────────────────────────────
Tahsis Tarihi          : 01/06/2024
Tapu Tarihi            : 15/08/2024
Üretim Başlangıcı      : 20/01/2024
İlk İhracat            : 15/03/2024

🔗 HIZLI ERİŞİM
─────────────────────────────────────────────────────────────────
☐ Parsel Detay Sayfası
☐ Üretim Raporları
☐ Finansal Raporlar
☐ Belge Arşivi
☐ İletişim Bilgileri

[KAPAT]  [DETAYLI RAPOR]  [YAZDIR]
```

---

## 📊 5. CBS VERİ GİRİŞİ VE GÜNCELLEME AKIŞI

```mermaid
graph TD
    Start[Veri Kaynakları] --> Source1[Manuel Veri Girişi<br/>OTB Müdürlüğü]
    Start --> Source2[Otomatik Veri Aktarımı<br/>Diğer Sistemler]
    Start --> Source3[Saha Verisi<br/>GPS/Mobil Uygulama]

    Source1 --> ManualEntry[Manuel Giriş Formu]
    ManualEntry --> Form1[Parsel Sahibi Bilgileri]
    ManualEntry --> Form2[Üretilen Ürün Bilgileri]
    ManualEntry --> Form3[Personel Sayısı]
    ManualEntry --> Form4[Tapu Durumu]
    ManualEntry --> Form5[Kredi Bilgileri]

    Form1 --> Validation
    Form2 --> Validation
    Form3 --> Validation
    Form4 --> Validation
    Form5 --> Validation

    Validation[Veri Doğrulama] --> Check1{Zorunlu Alanlar<br/>Dolu mu?}
    Check1 -->|Hayır| Error[Hata Mesajı<br/>Eksik Alanları Göster]
    Error --> ManualEntry

    Check1 -->|Evet| Check2{Veri Formatı<br/>Doğru mu?}
    Check2 -->|Hayır| FormatError[Format Hatası<br/>Düzeltme]
    FormatError --> ManualEntry

    Check2 -->|Evet| Check3{Koordinatlar<br/>Geçerli mi?}
    Check3 -->|Hayır| CoordError[Koordinat Hatası]
    CoordError --> ManualEntry

    Check3 -->|Evet| SaveData[Veritabanına Kaydet]

    Source2 --> AutoImport[Otomatik İçe Aktarım]
    AutoImport --> Import1[Tapu Müdürlüğünden<br/>Tapu Durumu]
    AutoImport --> Import2[Bakanlıktan<br/>Kredi Bilgileri]
    AutoImport --> Import3[OTB Sisteminden<br/>Tahsis Bilgileri]

    Import1 --> SaveData
    Import2 --> SaveData
    Import3 --> SaveData

    Source3 --> MobileApp[Mobil Uygulama<br/>Saha Ekibi]
    MobileApp --> GPS[GPS Koordinat<br/>Toplama]
    MobileApp --> Photo[Fotoğraf Çekimi]
    MobileApp --> Notes[Saha Notları]

    GPS --> SaveData
    Photo --> SaveData
    Notes --> SaveData

    SaveData --> UpdateGIS[CBS Veritabanı<br/>Güncelleme]

    UpdateGIS --> UpdateMap[Harita Katmanı<br/>Güncelleme]

    UpdateMap --> RenderMap[Harita Render Etme]

    RenderMap --> ApplyColor[Renk Kodlama<br/>Uygulama]

    ApplyColor --> ColorDeed{Tapu<br/>Durumu?}
    ColorDeed -->|Verildi| Green[🟢 Yeşil]
    ColorDeed -->|Verilmedi| Red[🔴 Kırmızı]
    ColorDeed -->|İşlemde| Yellow[🟡 Sarı]

    Green --> ColorCredit
    Red --> ColorCredit
    Yellow --> ColorCredit

    ColorCredit{Kredi<br/>Tipi?} -->|Bakanlık| BlueBorder[🔵 Mavi Çerçeve]
    ColorCredit -->|Kredisiz/Banka| GreenBorder[🟢 Yeşil Çerçeve]

    BlueBorder --> DisplayMap
    GreenBorder --> DisplayMap

    DisplayMap[Haritayı Göster] --> UserView[Kullanıcı Görüntüleme]

    UserView --> Analytics[Analitik ve Raporlama]

    style SaveData fill:#d4edda
    style Green fill:#28a745,color:#fff
    style Red fill:#dc3545,color:#fff
    style Yellow fill:#ffc107,color:#000
    style BlueBorder fill:#007bff,color:#fff
```

---

## 📊 6. CBS ANALİTİK VE RAPORLAMA

```mermaid
graph TD
    Start[CBS Analitik Modülü] --> QueryTypes[Sorgu Türleri]

    QueryTypes --> Spatial[Mekansal Sorgular]
    QueryTypes --> Attribute[Öznitelik Sorguları]
    QueryTypes --> Statistical[İstatistiksel Analizler]
    QueryTypes --> Temporal[Zamansal Analizler]

    Spatial --> SQ1[Alana Göre Seçim]
    Spatial --> SQ2[Mesafeye Göre Seçim]
    Spatial --> SQ3[Çakışma Analizi]
    Spatial --> SQ4[Komşuluk Analizi]

    SQ1 --> Example1[Örnek:<br/>5 dekardan büyük<br/>tüm parseller]

    Attribute --> AQ1[Tapu Durumuna Göre]
    Attribute --> AQ2[Kredi Tipine Göre]
    Attribute --> AQ3[Ürün Tipine Göre]
    Attribute --> AQ4[Personel Sayısına Göre]

    AQ1 --> Example2[Örnek:<br/>Tapusu verilmemiş<br/>tüm parseller]

    Statistical --> SA1[Toplam Alan Hesaplama]
    Statistical --> SA2[Ortalama Üretim]
    Statistical --> SA3[Toplam İstihdam]
    Statistical --> SA4[Kredi Dağılımı]

    SA1 --> Chart1[Grafik:<br/>Kategori Bazlı<br/>Alan Dağılımı]

    Temporal --> TA1[Tapu Veriliş Trendi]
    Temporal --> TA2[Üretim Trendi]
    Temporal --> TA3[İstihdam Trendi]
    Temporal --> TA4[Kredi Kullanım Trendi]

    Example1 --> Report
    Example2 --> Report
    Chart1 --> Report
    TA1 --> Report

    Report[Rapor Oluşturma] --> ReportTypes[Rapor Türleri]

    ReportTypes --> RT1[Özet Rapor]
    ReportTypes --> RT2[Detay Rapor]
    ReportTypes --> RT3[Tematik Harita]
    ReportTypes --> RT4[İstatistiksel Grafik]

    RT1 --> Export[Rapor Dışa Aktarma]
    RT2 --> Export
    RT3 --> Export
    RT4 --> Export

    Export --> Format[Format Seçimi]
    Format --> PDF[📄 PDF]
    Format --> Excel[📊 Excel]
    Format --> Image[🖼️ PNG/JPG]
    Format --> GeoJSON[🗺️ GeoJSON]
    Format --> KML[🗺️ KML Google Earth]

    PDF --> Download[İndirme]
    Excel --> Download
    Image --> Download
    GeoJSON --> Download
    KML --> Download

    style Report fill:#fff9e6
    style Download fill:#d4edda
```

---

## 📊 7. CBS KULLANICI ARAYÜZLERİ

### 7.1. Harita Görünümleri

```
┌─────────────────────────────────────────────────────────────────┐
│  OTB CBS - Harita Görünümü                      [⚙️ Ayarlar]     │
├─────────────────────────────────────────────────────────────────┤
│                                                                   │
│  [🗺️ Harita] [📊 Tablo] [📈 Analitik]                          │
│                                                                   │
│  ┌─────────────────┐ ┌───────────────────────────────────────┐  │
│  │ Filtreler       │ │                                       │  │
│  ├─────────────────┤ │                                       │  │
│  │ 📍 Kategori     │ │                                       │  │
│  │ ☐ Hayvansal     │ │         [HARITA ALANI]                │  │
│  │ ☑ Bitkisel      │ │                                       │  │
│  │ ☐ Su Ürünleri   │ │      Renk Kodlu Parseller             │  │
│  │ ☐ Sanayi        │ │                                       │  │
│  │                 │ │                                       │  │
│  │ 📋 Tapu Durumu  │ │                                       │  │
│  │ ☑ Tapu Var      │ │                                       │  │
│  │ ☑ Tapu Yok      │ │                                       │  │
│  │ ☑ İşlemde       │ │                                       │  │
│  │                 │ │                                       │  │
│  │ 💳 Kredi Tipi   │ │                                       │  │
│  │ ☑ Bakanlık      │ │                                       │  │
│  │ ☑ Kredisiz      │ │                                       │  │
│  │                 │ │                                       │  │
│  │ [Filtreyi      │ │                                       │  │
│  │  Uygula]        │ │                                       │  │
│  └─────────────────┘ └───────────────────────────────────────┘  │
│                                                                   │
│  ┌───────────────────────────────────────────────────────────┐  │
│  │ Renk Açıklamaları:                                        │  │
│  │ 🟢 Tapu Verildi  🔴 Tapu Verilmedi  🟡 Tapu İşlemde      │  │
│  │ 🔵 Bakanlık Kredisi (Çerçeve)  🟢 Kredisiz (Çerçeve)     │  │
│  └───────────────────────────────────────────────────────────┘  │
│                                                                   │
│  📊 Özet İstatistikler:                                          │
│  Toplam Parsel: 245  |  Tapu Var: 180  |  Toplam İstihdam: 4250│
└─────────────────────────────────────────────────────────────────┘
```

### 7.2. Tablo Görünümü

```
┌─────────────────────────────────────────────────────────────────┐
│  OTB CBS - Tablo Görünümü                                        │
├─────────────────────────────────────────────────────────────────┤
│  [Ara: ________]  [🔍]  [Dışa Aktar ▼]  [Sütun Seçimi ▼]       │
├──────┬────────────────┬─────────┬──────────┬─────────┬──────────┤
│Parsel│ Parsel Sahibi  │ Kategori│ Üretilen │ Personel│  Tapu    │
│  No  │    (YENİ)      │         │   Ürün   │  Sayısı │ Durumu   │
│      │                │         │  (YENİ)  │ (YENİ)  │  (YENİ)  │
├──────┼────────────────┼─────────┼──────────┼─────────┼──────────┤
│12345 │ Ali Yılmaz     │ Bitkisel│ Domates  │   38    │ 🟢 Var   │
│12346 │ Veli Tarım A.Ş│ Bitkisel│ Salatalık│   45    │ 🟢 Var   │
│12347 │ Ayşe Demir     │ Hayvansal│ Süt      │   12    │ 🔴 Yok   │
│12348 │ Mehmet Kaya    │ Bitkisel│ Domates  │   28    │ 🟡 İşlemde│
│12349 │ Tarım Koop.    │ Su Ürün.│ Balık    │   22    │ 🟢 Var   │
├──────┴────────────────┴─────────┴──────────┴─────────┴──────────┤
│ Toplam: 245 parsel  |  Sayfa: 1/49  |  [< Önceki] [Sonraki >]  │
└─────────────────────────────────────────────────────────────────┘
```

---

## 📊 8. CBS VERİ GİRİŞ FORMU

### OTB Müdürlüğü Veri Giriş Ekranı (YENİ)

```
┌─────────────────────────────────────────────────────────────────┐
│         CBS PARSEL VERİ GİRİŞ/GÜNCELLEME FORMU                  │
│              (OTB Müdürlüğü Kullanımı İçin)                     │
└─────────────────────────────────────────────────────────────────┘

📍 PARSEL SEÇİMİ
─────────────────────────────────────────────────────────────────
Parsel No               : [12345] [🔍 Parsel Ara]
veya
Haritadan Seç           : [🗺️ Haritayı Aç]

════════════════════════════════════════════════════════════════

👤 PARSEL SAHİBİ BİLGİLERİ (YENİ - Zorunlu)
─────────────────────────────────────────────────────────────────
☐ Gerçek Kişi   ☑ Tüzel Kişi

Ad Soyad/Unvan          : [Ali Yılmaz Tarım A.Ş._______________]
TC/Vergi No             : [1234567890_________________________]
Telefon                 : [0555 123 45 67____________________]
E-posta                 : [ali@tarim.com______________________]
Adres                   : [____________________________________]
Tahsis Tarihi           : [01/06/2024] 📅

════════════════════════════════════════════════════════════════

🏭 ÜRETİM BİLGİLERİ (YENİ - Zorunlu)
─────────────────────────────────────────────────────────────────
Üretilen Ürün           : [Domates (Sera)_____________________] *

Kategori                : ☐ Hayvansal  ☑ Bitkisel  ☐ Su Ürünleri

Üretim Kapasitesi       : [225] ton/yıl
Mevcut Üretim (Bu Yıl)  : [180] ton
Üretim Başlangıç Tarihi : [20/01/2024] 📅

Tesis Tipi              : [Jeotermal Sera____________________]
Tesis Alanı (m²)        : [4,500] m²

════════════════════════════════════════════════════════════════

👥 PERSONEL BİLGİLERİ (YENİ - Zorunlu)
─────────────────────────────────────────────────────────────────
Toplam Personel Sayısı  : [38] kişi *
   ↳ Kadın Personel     : [29] kişi
   ↳ Erkek Personel     : [9] kişi

Mevsimlik Personel      : [15] kişi
Sürekli Personel        : [23] kişi

════════════════════════════════════════════════════════════════

📋 TAPU DURUMU (YENİ - Zorunlu)
─────────────────────────────────────────────────────────────────
Tapu Durumu             : ☑ Tapu Verildi
                          ☐ Tapu Verilmedi
                          ☐ Tapu İşlemde

Tapu Tarihi             : [15/08/2024] 📅
Tapu No                 : [12345/2024_________________________]
Tahsis Belgesi No       : [OTB-2024-12345____________________]

CBS Renk Kodu           : 🟢 Yeşil (Otomatik)

════════════════════════════════════════════════════════════════

💳 KREDİ BİLGİLERİ
─────────────────────────────────────────────────────────────────
Kredi Kullanıyor mu?    : ☑ Evet  ☐ Hayır

Kredi Tipi              : ☑ Bakanlık Kredisi (Proses A)
                          ☐ Kredisiz/Banka Kredisi (Proses B)

Kredi Tutarı            : [2,500,000] TL
Kullanılan Kredi        : [2,500,000] TL
Kalan Borç              : [1,850,000] TL
Ödeme Durumu            : ☑ Düzenli  ☐ Gecikme  ☐ Takipte

CBS Renk Kodu (Çerçeve) : 🔵 Mavi (Otomatik)

════════════════════════════════════════════════════════════════

📊 YATIRIM BİLGİLERİ
─────────────────────────────────────────────────────────────────
Toplam Yatırım          : [3,200,000] TL
Tamamlanma Oranı        : [%100] ████████████ 100%
Yatırım Başlangıç       : [01/03/2023] 📅
Yatırım Bitiş           : [31/12/2023] 📅

════════════════════════════════════════════════════════════════

🌍 YEŞİL OTB BİLGİLERİ (Opsiyonel)
─────────────────────────────────────────────────────────────────
Enerji Kaynağı          : ☐ Jeotermal  ☐ GES  ☐ RES  ☐ Biokütle
Enerji Tasarrufu        : [%82] ████████-- 82%
Su Tasarrufu            : [%65] ██████---- 65%
Karbon Ayak İzi         : [-45] ton CO2/yıl

════════════════════════════════════════════════════════════════

📎 EKLER
─────────────────────────────────────────────────────────────────
Fotoğraflar             : [📷 3 Fotoğraf Yüklendi]
Belgeler                : [📄 5 Belge Yüklendi]
Diğer                   : [📎 Dosya Yükle]

════════════════════════════════════════════════════════════════

[❌ İptal]  [💾 Kaydet]  [💾 Kaydet ve CBS'yi Güncelle]
```

---

## 📊 9. CBS PERFORMANS VE TEKNİK ÖZELLİKLER

### 9.1. Teknik Altyapı

```mermaid
graph TD
    Start[CBS Teknik Altyapı] --> Frontend[Ön Yüz]
    Start --> Backend[Arka Yüz]
    Start --> Database[Veritabanı]
    Start --> MapServer[Harita Sunucusu]

    Frontend --> FE1[Web Tarayıcı]
    FE1 --> FE2[Harita Kütüphanesi:<br/>Leaflet / OpenLayers]
    FE2 --> FE3[JavaScript Framework:<br/>React / Vue.js]

    Backend --> BE1[API Sunucusu]
    BE1 --> BE2[Node.js / Python]
    BE2 --> BE3[RESTful API]
    BE3 --> BE4[Authentication<br/>Authorization]

    Database --> DB1[İlişkisel DB:<br/>PostgreSQL]
    DB1 --> DB2[PostGIS Uzantısı<br/>Coğrafi Veri Desteği]
    DB2 --> DB3[Geometri Tipler i:<br/>Point, LineString,<br/>Polygon]

    MapServer --> MS1[GeoServer]
    MS1 --> MS2[WMS (Web Map Service)]
    MS1 --> MS3[WFS (Web Feature Service)]
    MS1 --> MS4[WCS (Web Coverage Service)]

    FE2 --> Request[Harita Talebi]
    Request --> MS2
    MS2 --> Render[Harita Render]
    Render --> Response[Harita Görüntüsü]
    Response --> FE1

    BE3 --> DataRequest[Veri Talebi]
    DataRequest --> DB2
    DB2 --> DataResponse[Veri Yanıtı]
    DataResponse --> BE3
    BE3 --> FE3

    style DB2 fill:#fff9e6
    style MS2 fill:#e6ffe6
```

### 9.2. Veri Modeli

**Parsel Tablosu (parcels)**

| Alan Adı | Veri Tipi | Açıklama |
|---|---|---|
| id | SERIAL PRIMARY KEY | Otomatik artan ID |
| parcel_no | VARCHAR(50) UNIQUE | Parsel numarası |
| ada_no | VARCHAR(50) | Ada numarası |
| geometry | GEOMETRY(Polygon, 4326) | Parsel sınırı (WGS84) |
| area_sqm | DECIMAL(12,2) | Alan (m²) |
| area_dekar | DECIMAL(10,2) | Alan (dekar) |
| category | VARCHAR(50) | Kategori (Hayvansal/Bitkisel/Su Ürünleri) |
| owner_name | VARCHAR(200) | **YENİ:** Parsel sahibi |
| owner_tc_tax | VARCHAR(20) | **YENİ:** TC/Vergi No |
| owner_phone | VARCHAR(20) | **YENİ:** Telefon |
| owner_email | VARCHAR(100) | **YENİ:** E-posta |
| product_name | VARCHAR(200) | **YENİ:** Üretilen ürün |
| production_capacity | DECIMAL(10,2) | Üretim kapasitesi (ton/yıl) |
| personnel_total | INTEGER | **YENİ:** Toplam personel sayısı |
| personnel_female | INTEGER | **YENİ:** Kadın personel |
| personnel_male | INTEGER | **YENİ:** Erkek personel |
| deed_status | VARCHAR(20) | **YENİ:** Tapu durumu (given/not_given/processing) |
| deed_date | DATE | Tapu tarihi |
| deed_no | VARCHAR(50) | Tapu numarası |
| credit_type | VARCHAR(20) | Kredi tipi (ministry/none_bank) |
| credit_amount | DECIMAL(12,2) | Kredi tutarı |
| debt_amount | DECIMAL(12,2) | Kalan borç |
| created_at | TIMESTAMP | Oluşturulma tarihi |
| updated_at | TIMESTAMP | Güncellenme tarihi |
| created_by | INTEGER | Oluşturan kullanıcı ID |
| updated_by | INTEGER | Güncelleyen kullanıcı ID |

---

## 🎯 ÖNEMLİ NOKTALAR VE YENİ GEREK SİNİMLER

### ✅ CBS Kritik Noktaları (23.09.2025 Toplantı Notları):

1. **Özel CBS Harita Sistemi (YENİ):**
   - ✨ Coğrafya Bilgi Sistemi Haritalar Bize Özel mi olacak? → EVET
   - OTB'ye özel tasarlanmış harita sistemi
   - Özel renk kodlama sistemi
   - Özel veri katmanları

2. **Parsel Sahibi Bilgisi (YENİ - Zorunlu):**
   - ✨ Parsel Sahibi bilgisi mutlaka olmalı
   - Ad Soyad / Şirket Ünvanı
   - TC/Vergi No
   - İletişim bilgileri
   - Tahsis tarihi

3. **Üretilen Ürün Bilgisi (YENİ - Zorunlu):**
   - ✨ Üretilen Ürün bilgisi mutlaka olmalı
   - Ürün adı ve türü
   - Üretim kapasitesi
   - Mevcut üretim miktarı

4. **Personel Sayısı (YENİ - Zorunlu):**
   - ✨ Personel Sayısı bilgisi mutlaka olmalı
   - Toplam personel
   - Kadın/Erkek ayrımı
   - Mevsimlik/Sürekli ayrımı

5. **Tapu Durumu Renk Kodlaması (YENİ - Kritik):**
   - ✨ Tapusu verildi verilmedi ayrımı parselizasyonda renk ayrımı
   - 🟢 **Yeşil:** Tapu verildi
   - 🔴 **Kırmızı:** Tapu verilmedi
   - 🟡 **Sarı:** Tapu işlemde (Opsiyonel)

6. **Kredi Tipi Gösterimi:**
   - 🔵 **Mavi Çerçeve:** Bakanlık kredisi kullananlar (Proses A)
   - 🟢 **Yeşil Çerçeve:** Kredisiz/Banka kredisi (Proses B)

7. **OTB Müdürlüğü Veri Giriş Sorumluluğu:**
   - OTB Müdürlüğü tüm verileri sisteme girmekle sorumlu
   - Manuel veri girişi ara yüzü gerekli
   - Veri doğrulama mekanizmaları

---

## 📊 SÜREÇ ÖZETİ

### **CBS Veri Akış Özeti:**

```
Veri Kaynakları
    ↓
YENİ: OTB Müdürlüğü Veri Girişi:
  - YENİ: Parsel Sahibi Bilgileri
  - YENİ: Üretilen Ürün Bilgileri
  - YENİ: Personel Sayısı
  - YENİ: Tapu Durumu
  - Kredi Bilgileri
    ↓
Veri Doğrulama ve Kontrol
    ↓
CBS Veritabanına Kaydetme
    ↓
Harita Katmanı Güncelleme
    ↓
YENİ: Renk Kodlama Uygulama:
  🟢 Yeşil: Tapu Verildi
  🔴 Kırmızı: Tapu Verilmedi
  🟡 Sarı: Tapu İşlemde
  🔵 Mavi Çerçeve: Bakanlık Kredisi
  🟢 Yeşil Çerçeve: Kredisiz
    ↓
Haritayı Kullanıcıya Gösterme
    ↓
Kullanıcı Etkileşimi:
  - Parsel Tıklama → Detay Bilgi
  - Filtre Uygulama
  - Arama
  - Raporlama
    ↓
Analitik ve Raporlar:
  - Tapu Durumu Raporları
  - Üretim Raporları
  - İstihdam Raporları
  - Kredi Raporları
```

---

## 🎯 SONUÇ

Bu doküman, **CBS (Coğrafi Bilgi Sistemi)** ve **Veri Yönetimi** süreçlerini 23.09.2025 toplantı notlarındaki güncellemeler ışığında detaylı olarak açıklamaktadır:

- ✅ **Özel CBS Sistemi:** OTB'ye özel harita ve renk kodlama sistemi
- ✅ **Parsel Sahibi Bilgisi:** Zorunlu veri alanı, detaylı sahibiyet takibi
- ✅ **Üretilen Ürün Bilgisi:** Üretim türü ve miktarı takibi
- ✅ **Personel Sayısı:** İstihdam takibi (Kadın/Erkek ayrımı ile)
- ✅ **Tapu Durumu Renk Kodlama:** Görsel tapu durumu takibi (Yeşil/Kırmızı/Sarı)
- ✅ **Kredi Tipi Gösterimi:** Kredi türü çerçeve rengi ile (Mavi/Yeşil)
- ✅ **OTB Müdürlüğü Veri Girişi:** Manuel veri giriş sistemi ve sorumluluklar
- ✅ **Analitik ve Raporlama:** Kapsamlı analiz ve raporlama yetenekleri

---

**📅 Son Güncelleme:** 23.09.2025 Toplantı Notları Temel Alınarak Hazırlanmıştır.
