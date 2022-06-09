


using System.ComponentModel;

namespace TheModels
{
   [Flags]
   public enum SystemPayment
    {
        [Description("اختر النظام")]
        None = 0,
        [Description("اقساط مع دفع مقدم")]
        Installments = 1,
        [Description("دفع كامل المبلغ")]
        Cash = 2,
        [Description("دفع دفع حجز وسداد على دفعات")]
        Reservation = 4
    }

    [Flags]
    public enum PaymentIs
    {
        [Description("اختر الدفع")]
        None = 0,
        [Description("دفعة اولى من الاقساط")]
        DownPayment = 1,
        [Description("سداد قسط")]
        Installment = 2,
        [Description("دفع دفعة")]
        Payment = 4
    }

    [Flags]
    public enum CashPayment
    {
        [Description("اختر طريقة الدفع")]
        None = 0,
        [Description("نقدى")]
        Cash = 1,
        [Description("فيزا")]
        Visa = 2,
        [Description("شيـــك")]
        Sheek =4
    }

    [Flags]
    public enum Months
    {
        Jan = 1,
        Feb = 2,
        Mar = 3,
        Apr = 4,
        May = 5,
        June = 6,
        Jul = 7,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        November = 11,
        December = 12,

    }

    [Flags]
    public enum PaymentSaleOF
    {
        [Description("اختر من حساب")]
        None = 0,
        [Description("من حساب الراتب الثابت")]
        Fromsale = 1,
        [Description("من حساب نسبة المبيعات")]
        FromPercant = 2,
    }

    [Flags]
    public enum TypeSalery
    {
        [Description("اختر طريقة الراتب")]
        None = 0,
        [Description("راتب ثابت فقط")]
        Baseonly = 1,
        [Description("راتب ثابت مع نسبة")]
        BaseAndPersant = 2,
        [Description("نسبة فقط")]
        Persant = 4
    }

    [Flags]
    public enum SocialMedia : byte
    {
        FaceBook = 1,
        Twitter = 2,
        YouTupe = 4,
        Telegram = 8,
        Instgram = 16,
        locations = 32,
        Google = 64,
        Email = 128
    }

    [Flags]
    public enum TitelSubject 
    {
        [Description("مقدمة الصفحة بانر")]
        Intro = 0b_0000_0001,
        [Description("خدمات عاملة")]
        Servives = 0b_0000_0010,
        [Description("موضوع للشرح")]
        Subject = 0b_0000_0100,
        [Description("مشاريع الشركة")]
        Projects = 0b_0000_1000,
        [Description("عن الشركة")]
        AboutUs = 0b_0001_0000,
        [Description("اعمال سابقة")]
        CompanyHetory = 0b_0010_0000,
        [Description("الصفحة رئسية")]
        Index = 0b_0100_0000,
        [Description("تواصل معنا")]
        Contant = 0b_1000_0000,
        [Description("تواصل معنا")]
        Images = 0b_0001_0000_0000,
        [Description("مقدمة الصفحة الرئسية")]
        IndexIntro = Intro | Index,
        [Description("مقدمة الصفحة خدمات")]
        IndexService = Intro | Servives,
        [Description("موضوع صفحة رئيسية")]
        IndexSubject = Subject | Index,
        [Description("معرض الصورة صفحة رئيسية")]
        IndexImages = Images | Index,
        [Description("موضوع صفحة خدمات")]
        servicesubject = Subject | Servives,
        [Description("مقدمة صفحة خدمات")]
        serviceIntro = Intro | Servives,

    }

    [Flags]
    public enum Jop : byte
    {
        [Description("اختر فئة الوظيفة")]
        None = 0,
        [Description("سكرتريا او مدخل بيانات")]
        DataEntry = 1,
        [Description("تسويق")]
        Marketing = 2,
        [Description("مهندس")]
        Engineer = 4,
        [Description("مــدير")]
        Maneger = 8,
        [Description("مهندس اى تى")]
        IT = 16,
        [Description("مدير مهندسين")]
        ISManegerEngineer = Maneger | Engineer,
        [Description("مدير تسويق")]
        ISManegerMarketing = Maneger | Marketing,
        [Description("مدير اى تى")]
        ISManegerIT = Maneger | IT,


    }

    [Flags]
    public enum Specialty : byte
    {
        [Description("اختر نشاط الشركة")]
         None = 0 ,
        [Description("للتشطيب والديكور")]
        decorations = 1,
        [Description("بيع مسلتزمات ديكور")]
        SellingDecorativeItems = 2,
        [Description("مقاولات استثمار عقارى")]
        Building = 4,
        [Description("بيع مواد بناء")]
        BuildingMaterials = 8,
        [Description("نشاط اخر")]
        Other = 16
    }

    [Flags]
    public enum Selections
    {
        [Description("اختر مدفوع الى")]
        None = 0,
        [Description("الى حاسب صانع")]
        Maker = 1,
        [Description("الى حساب خامة")]
        Materail = 2,
        [Description("الى حساب اخر")]
        Other = 3,
    }

    [Flags]
    public enum AddAccount
    {
        [Description("اختر طريقة الحساب")]
        None = 0,
        [Description("حساب تم دفعة")]
        Cost = 1,
        [Description("حساب للمقايسة")]
        Costruct = 2
    }

    [Flags]
    public enum DoPayment
    {
        [Description("هل ستدفع من المبلغ")]
        None = 0,
        [Description("سادفع جزء")]
        YesNotAll = 1,
        [Description("لن ادفع شى الان")]
        No = 2,
        [Description("دفع كامل المبلغ")]
        All = 3
    }

    [Flags]
    public enum AddingBy: byte
    {
        [Description("تم عن طريق")]
        None = 0,
        [Description("موظف تسويق")]
        Emlpyee = 2,
        [Description("شركة او نشاط")]
        Company = 4
    }

    [Flags]
    public enum UnitIs : byte
    {
        [Description("اختر الوحدة المراد تشطيبها")]
        None = 0,
        [Description("وحدة من جديد")]
        IsNewUnit = 2,
        [Description("وحدة مباعة من مشارع الشركة")]
        UnitResertvation = 4
    }

    [Flags]
    public enum YouDoApp : byte
    {
        [Description("اختر")]
        None = 0,
        [Description("المرة الاولى للاستخدام الابليكيشن")]
        IfFirst = 2,
        [Description("ليست المرة الاولى للاستخدم الابليكيشن ومعى نسخة بيانات")]
        Islast = 4
    }

    public enum IsCompany: byte
    {
        [Description("اختر التصنيف")]
        None = 0,
        [Description("شركة منافسة")]
        Iscompetitivecompany = 1,
        [Description("شركة صديقة")]
        IsCompanyToBenefit = 2
    }

}