namespace UniBase.Models
{
    using DecanatLiteWeb.Models;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class ДекВсеДанныеСтудента : IBaseWebModel<ДекВсеДанныеСтудента>, IBaseModel
    {
        [Column(Order = 6)]

        public string? ФИО { get; set; }

        public string? Зачетка { get; set; }


        public string? Название { get; set; }


        public string? Квалификация { get; set; }


        public string? Название_Спец { get; set; }


        public string? Срок_Обучения { get; set; }


        public string? Учебный_План { get; set; }

        public string? Сокращение { get; set; }


        public string? Факультет { get; set; }

        public int? Курс { get; set; }


        public string? Специальность { get; set; }


        public string? СрокОбучения { get; set; }


        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код { get; set; }


        [Column(Order = 1)]

        public string? Имя { get; set; }


        public string? Отчество { get; set; }

        public int? Статус { get; set; }

        public int? Код_Группы { get; set; }

        public short? Год_Поступления { get; set; }


        public string? Пол { get; set; }


        public string? Изучаемый_Язык { get; set; }


        [Column(Order = 2)]
        public bool Долг { get; set; }


        public string? Национальность { get; set; }

        public DateTime? Дата_Рождения { get; set; }


        public string? Отличник_УЗ { get; set; }

        public bool? Пособие { get; set; }


        public string? Номер_Мед_Полиса { get; set; }


        public string? Серия_Мед_Полиса { get; set; }


        public string? Страна_ПП { get; set; }


        public string? Регион_ПП { get; set; }


        public string? Город_ПП { get; set; }


        public string? Поселок_ПП { get; set; }


        public string? Индекс_ПП { get; set; }


        public string? Улица_ПП { get; set; }


        public string? Дом_Кв_ПП { get; set; }


        [Column(Order = 3)]
        public string? ПолныйАдрес { get; set; }


        [Column(Order = 4)]
        public string? Адрес2 { get; set; }


        public string? Телефон_ПП { get; set; }


        public string? E_Mail { get; set; }

        public bool? Общежитие { get; set; }


        public string? Номер_Комнаты { get; set; }

        public int? Номер_Общежития { get; set; }


        public string? Кем_Выдан { get; set; }


        public string? Номер_Паспорта { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Дата_Выдачи { get; set; }

        public bool? Наличие_Матери { get; set; }

        public bool? Наличие_Отца { get; set; }


        public string? ФИО_Матери { get; set; }


        public string? Место_Раб_Матери { get; set; }


        public string? Должность_Матери { get; set; }


        public string? ФИО_Отца { get; set; }


        public string? Место_Раб_Отца { get; set; }


        public string? Должность_Отца { get; set; }

        public byte? Число_Братьев_И_Сестер { get; set; }


        public string? Страна_Родители { get; set; }


        public string? Регион_Родители { get; set; }


        public string? Город_Родители { get; set; }


        public string? Поселок_Родители { get; set; }


        public string? Индекс_Родители { get; set; }


        public string? Улица_Родители { get; set; }


        public string? Дом_Кв_Родители { get; set; }


        public string? Телефон_Родители { get; set; }

        public bool? Опекунство { get; set; }

        public bool? Состоит_В_Браке { get; set; }

        public byte? Число_Детей { get; set; }


        public string? Примечание { get; set; }


        public string? НомерЛД { get; set; }


        public string? Льготы { get; set; }


        public string? Тип_Удостоверения { get; set; }


        public string? Серия_Аттестата { get; set; }


        public string? Номер_Аттестата { get; set; }


        public string? Тип_Образ_Документа { get; set; }

        public DateTime? ДатаПодачиДокументов { get; set; }


        public string? ПереводДокументов { get; set; }

        public bool? НеМестный { get; set; }

        public int? ГодРождения { get; set; }


        public string? ФормаОбучения { get; set; }


        public string? НаучнаяСпециальность { get; set; }

        public DateTime? ДатаЗачисления { get; set; }


        public string? НомерПриказаОЗачислении { get; set; }

        public DateTime? ДатаОкончания { get; set; }


        public string? МестоРаботы { get; set; }


        public string? ПрикрепКафедра { get; set; }


        public string? НаучныйРуководитель { get; set; }


        public string? КандФилософия { get; set; }


        public string? КандИностранный { get; set; }


        public string? КандСпециальность { get; set; }


        public string? Аттестация1 { get; set; }


        public string? Аттестация2 { get; set; }


        public string? Аттестация3 { get; set; }


        public string? Аттестация4 { get; set; }


        public string? ДополнОтпуск { get; set; }


        public string? Командировки { get; set; }

        public long? КодОригинала { get; set; }

        public bool? Село { get; set; }


        public string? КвалификацияСтудента { get; set; }


        public string? Стаж { get; set; }


        public string? Должность { get; set; }

        public DateTime? ПродлениеСессии { get; set; }


        public string? УчебныйПлан { get; set; }

        public bool? Кандидатские { get; set; }

        public bool? Соискатель { get; set; }

        public bool? ДопКвалификация { get; set; }


        public string? ИНН { get; set; }


        public string? НомерСоцСтрахования { get; set; }


        public string? Номер_договора { get; set; }


        public string? Фото { get; set; }

        public bool? Пропуск { get; set; }


        public string? ЧитательскийБилет { get; set; }

        public bool? СокращенноеОбучение { get; set; }

        public bool? ПродленоОбучение { get; set; }


        public string? ПриписноеСвидетельство { get; set; }

        public int? КодВоенкомата { get; set; }


        public string? Военкомат { get; set; }


        public string? ВоенкоматАдрес { get; set; }


        public string? ВоенкоматНачальник { get; set; }


        public string? ВоенкоматТелефон { get; set; }


        public string? ВоенныйБилет { get; set; }


        public string? ГруппаУчета { get; set; }


        public string? КатегорияУчета { get; set; }


        public string? Состав { get; set; }


        public string? ВоинскоеЗвание { get; set; }


        public string? ВоеннСпециальность { get; set; }


        public string? ВоеннГодность { get; set; }


        public string? ВоеннСпецУчет { get; set; }


        public string? ВоенДолжность { get; set; }


        public string? ВоенЗвание { get; set; }


        public string? ВоенОрган { get; set; }


        public string? ВоенМестоСлужбы { get; set; }

        public DateTime? ВоенныйБилетДата { get; set; }


        public string? ВоенкоматВидУчета { get; set; }

        public bool? ВоенкоматОтсрочка { get; set; }

        public bool? ВоенкоматПоПриписке { get; set; }


        public string? Гражданство { get; set; }

        public DateTime? Даты_Выдачи_Аттестата { get; set; }


        public string? БывшаяФамилия { get; set; }

        public bool? Иностранец { get; set; }

        public string? Район_ПП { get; set; }


        public string? АкадемСправка { get; set; }


        [Column(Order = 5)]

        public string? Фамилия { get; set; }


        public string? Название_Специальности { get; set; }

        public bool? Второе_Образование { get; set; }

        public bool? Заблокирован { get; set; }


        public string? ТемаДиплома { get; set; }


        public string? РегистрационныйНомер { get; set; }

        public DateTime? ДатаВыдачи { get; set; }

        public DateTime? ДатаРешения { get; set; }


        public string? НомерДиплома { get; set; }


        public string? Подразделение { get; set; }

        public int? КодФакультета { get; set; }

        public int? УслОбучения { get; set; }

        public bool? Слушатель { get; set; }

        public bool? СоответсвиеВПО { get; set; }


        public string? УчебныйГод { get; set; }


        public string? Тип_УЗ { get; set; }

        public bool? СокращеннаяФорма { get; set; }


        public string? Декан { get; set; }


        public string? Форма_ОбученияСокр { get; set; }


        public string? Форма_Обучения { get; set; }

        public int? Форма_ОбученияКод { get; set; }

        public int? Уровень { get; set; }


        public string? ОКСО { get; set; }


        public string? Специализация { get; set; }

        public int? Код_Профиль { get; set; }


        public string? Уч_Заведение { get; set; }


        public string? Где_Находится_УЗ { get; set; }

        public short? Год_Окончания_УЗ { get; set; }


        public string? Основания { get; set; }


        public string? ТекстПриказа { get; set; }


        public string? МестоРождения { get; set; }


        public string? ЗамДекана { get; set; }


        public string? Мобильный { get; set; }


        public string? КодПодраздел { get; set; }


        public string? ОбщежитиеДоговор { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ОбщежитиеДата { get; set; }


        public string? ОбщежитиеПл { get; set; }


        public string? Район_Родители { get; set; }

        public int? КодОбщежития { get; set; }


        public string? Префикс { get; set; }

        public bool? АкадемСтипендия { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? АкадемСтипендияС { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? АкадемСтипендияПо { get; set; }

        public bool? СоцСтипендия { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? СоцСтипендияС { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? СоцСтипендияПо { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ПродленаСессия { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ДатаНачСессии { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ДатаКонСессии { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ДатаАкадОтпускС { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ДатаАкадОтпуск { get; set; }


        public string? УсловияОбучения { get; set; }

        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Код_Студента { get; set; }


        public string? РодПадеж { get; set; }


        public string? Профиль { get; set; }

        //[Column(TypeName = "text")]
        //public string? Описание { get; set; }

        public int? Код_филиала { get; set; }


        public string? Телефон { get; set; }


        public string? Аудитория { get; set; }


        public string? ВнутрТелефон { get; set; }


        public string? EMail { get; set; }


        public string? УсловияТекст { get; set; }

        public int? Код_Факультета { get; set; }


        public string? Подпись1 { get; set; }


        public string? Подпись2 { get; set; }


        public string? Подпись3 { get; set; }


        public string? Подпись4 { get; set; }


        public string? ПодписьЗФ1 { get; set; }


        public string? ПодписьЗФ2 { get; set; }


        public string? ПодписьЗФ3 { get; set; }


        public string? ПодписьЗФ4 { get; set; }


        public string? СНИЛС { get; set; }

        public string? Выпускники_Примечания_Администратора { get; set; }


        public string? Выпускники_Факультет { get; set; }


        public string? Квартира_Родители { get; set; }


        public string? Квартира_ПП { get; set; }

        public int? Код_Специальности { get; set; }

        public bool? ОтчисленБезВосстановления { get; set; }

        public int? Код_Кафедры { get; set; }

        public double? СрБаллАттестата { get; set; }

        public Guid? uid_1c { get; set; }

        public Guid? GUID { get; set; }


        public string? Сан { get; set; }


        public string? Шифр { get; set; }

    }
}
