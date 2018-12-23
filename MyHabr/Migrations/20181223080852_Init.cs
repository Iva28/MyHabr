﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHabr.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    Avatar = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Preview = table.Column<string>(maxLength: 1500, nullable: false),
                    Text = table.Column<string>(maxLength: 5000, nullable: false),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Image = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Text = table.Column<string>(maxLength: 500, nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "Email", "Login", "Password", "RegistrationDate" },
                values: new object[] { 1, "http://romanroadtrust.co.uk/wp-content/uploads/2018/01/profile-icon-png-898-300x300.png", "user@mail.ru", "user", "user", new DateTime(2018, 12, 23, 12, 8, 52, 413, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Date", "Image", "Preview", "Text", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 12, 23, 12, 8, 52, 515, DateTimeKind.Local), "https://habrastorage.org/webt/sc/yp/80/scyp80qki4ltgtff4ddvrmxrdk4.png", "6 декабря 2018 года парламент Австралии принял Assistance and Access Bill 2018 — поправки к Telecommunications Act 1997 о правилах оказания услуг электросвязи.».", @"Говоря юридическим языком, эти поправки «устанавливают нормы для добровольной и обязательной помощи телекоммуникационных компаний правоохранительным органам и спецслужбам в отношении технологий шифрования после получения запросов на техническую помощь.

                По сути это аналог российского «закона Яровой», который требует от интернет-компаний обязательной расшифровки трафика по запросу правоохранительных органов. В отдельных моментах австралийский закон даже более суровый, чем российский. Некоторые эксперты недоумевают, как такое законодательство вообще могло быть принято в демократической стране и называют его «опасным прецедентом».

                Узаконенный саботаж

                Разработка нового закона продолжалась более года, он чрезвычайно сложный и объёмный. В начале декларируется «золотое правило», на что не имеют права правоохранительные органы: они не имеют права требовать от IT-компаний внедрения в свои продукты «системных уязвимостей». Однако в тексте нет определения, что считается системной уязвимостью.

                Дальше утверждается, что IT-компании обязаны помогать в расшифровке сообщений пользователей, которые попали в разработку правоохранительными органами. Список обязательной «помощи» включает в себя такие пункты:

                удаление одной или нескольких форм электронной защиты;
                предоставление технической информации;
                облегчение доступа к услугам и оборудованию;
                установка программного обеспечения;
                изменение технологий;
                сокрытие факта, что сделано что-либо из перечисленного.

                Последний пункт особенно примечателен. Речь идёт не только о сокрытии информации от пользователей, чтобы те не заблокировали установку свежего «обновления безопасности» на свои устройства. Всё гораздо интереснее.

                Если посмотреть определение “designated communication provider“ в параграфе 317C (пункт 6), то даже отдельный разработчик, если он гражданин Австралии, должен выполнить требование правоохранительных органов, внедрить бэкдор в программу и обязан скрыть эту информацию от своего работодателя, иначе ему грозит тюремное заключение.", "Любая интернет-компания обязана тайно изменить программный код по требованию властей", 1 },
                    { 2, new DateTime(2018, 12, 23, 12, 8, 52, 515, DateTimeKind.Local), "https://habrastorage.org/webt/go/dv/qj/godvqj9smomw8lpr4kiymtkxnzg.jpeg", @"Онбординг—это процесс, в рамках которого вы знакомите пользователя с вашим продуктом.

                Чаще всего онбординг осуществляется тремя способами:

                1. Прежде чем пустить пользователя в систему, вы показываете несколько экранов, в которых объясняете суть вашего сервиса. Обычно, этот метод используется в мобильных приложениях, когда вам показывается картинка и поясняющий текст. Да, это те самые экраны, которые мы пролистываем, а потом пытаемся разобраться в интерфейсе самостоятельно.

                2. Вы можете пошагово помочь пользователю совершить первые действия. Basecamp по входу в систему предлагает создать первый проект, запрашивая название, сроки и документы. Pinterest предлагает подписаться на интересные темы, а Apple Music на любимых исполнителей. Таким образом формируется персональная лента, и продукт становится новому пользователю ближе.

                3. Вы можете и вовсе не использовать пошаговые сценарии и, вместо этого, на каждом экране выдавать контекстные подсказки. Например, когда пользователь впервые попадает на страницу заказов, вы можете указать на ключевые элементы (кнопку создания заказа, фильтры, список).", @"Поиск идей

                Дэвид Огилви считает, что великие идеи приходят из подсознания, поэтому в своей книге “О рекламе” он советует периодически отключать процесс рационального мышления.

                Например, отправиться на долгую прогулку, принять ванну или выпить рюмку/бокал любимого напитка.

                Но, прежде чем сделать это, нужно наполнить мозг информацией о задаче, над которой вы работаете. Иначе к вам будут приходить идеи, не относящиеся к решаемой проблеме.

                Я не раз замечал, что идеи часто приходят по пути в магазин, в душе или во время чтения. В эти моменты в голове начинается суматоха, в которой хаотично появляются разные мысли. Некоторые соединяются с другими и получаются суперидеи. Главное?—?успеть их записать.

                Именно поэтому, личные проблемы могут мешать развитию карьеры, так как будут отвлекать от рабочих задач. Видимо, поэтому, многим лидерам присущи эгоистические черты, которые позволяют не обращать внимание на чувства других людей и полностью фокусироваться на профессиональных задачах.

                Если подвести итог, то поиск креативных идей выполняется в три шага:

                1. Изучить всю доступную информацию по стоящей перед вами задаче.
                2. Отвлечься на какое-либо занятие, не требующее интеллектуальной нагрузки.
                3. Дать мыслям блуждать и не упустить пришедшие идеи.", "Дизайн-дайджест: онбординг, фидбек, поиск идей и принятие решений", 1 },
                    { 3, new DateTime(2018, 12, 23, 12, 8, 52, 515, DateTimeKind.Local), "https://habrastorage.org/getpro/habr/post_images/9cf/0ad/c99/9cf0adc990a16a5f4b3589254d6d1ecf.png", "Это классическая статья о том, как наша команда проверила открытый проект LibrePCB с помощью статического анализатора кода PVS-Studio. Однако статья интересна тем, что проверка осуществлялась внутри Docker контейнера. Если вы использует контейнеры, то надеемся, что статья продемонстрирует ещё один простой способ встроить анализатор в процесс разработки.", @"LibrePCB

                LibrePCB — это свободное ПО для проектирования электронных схем и печатных плат. Код программы написан на языке C++, а для построения графического интерфейса используется Qt5. Недавно состоялся первый официальный релиз этого приложения, ознаменовавший собою стабилизацию собственного формата файлов (*.lp, *.lplib). Бинарные пакеты подготовлены для Linux, macOS и Windows.
                LibrePCB — это маленький проект, содержащий всего около 300 000 непустых строк кода на языке C и C++. При этом 25% непустых строк — это комментарии. Кстати, это большой процент для комментариев. Скорее всего, это связано с тем, что в проекте много маленьких файлов, существенную часть которых занимают заголовочные комментарии с информаций о проекте и лицензии. Код на сайте GitHub: LibrePCB.

                Проект показался нам интересным, и мы решили проверить его. А вот результаты проверки оказались уже не такими интересными. Да, нашлись настоящие ошибки. Но не было чего-то особенного, о чём непременно надо рассказать читателям наших статей. Возможно, мы бы не стали писать статью и ограничились отправкой найденных ошибок разработчикам проекта. Однако интересным моментом стало то, что проект был проверен внутри Docker образа, и поэтому мы решили, что написать статью всё же стоит.

                Docker

                Docker — программное обеспечение для автоматизации развёртывания и управления приложениями в среде виртуализации на уровне операционной системы. Оно позволяет «упаковать» приложение со всем его окружением и зависимостями в контейнер. Хотя этой технологии около пяти лет и многие компании давно внедрили Docker в инфраструктуры своих проектов, в мире open source это было не очень заметно до недавнего времени.

                Наша компания очень плотно работает с open source проектами, проверяя исходный код с помощью собственного статического анализатора PVS-Studio. На данный момент проверено более 300 проектов. Самым сложным в этой деятельности всегда была компиляция чужих проектов, но внедрение Docker-контейнеров сильно упростило этот процесс.

                Первый опыт проверки open source проекта в Docker был с Azure Service Fabric. Там разработчики сделали монтирование каталога исходных файлов к контейнеру и интеграция анализатора ограничилась редактированием одного из скриптов, выполняющихся в контейнере", "Проверка проекта LibrePCB с помощью PVS-Studio внутри Docker контейнера", 1 },
                    { 4, new DateTime(2018, 12, 23, 12, 8, 52, 515, DateTimeKind.Local), "https://habrastorage.org/webt/cc/a8/6i/cca86i0z-kir9y5tomdwywude5c.png", @"Привет, Хабр!

                Каждый современный браузер сейчас позволяет работать с ES6 Modules. 

                На первый взгляд кажется, что это совершенно бесполезная вещь — ведь все мы пользуемся сборщиками, которые заменяют импорты на свои внутренние вызовы. Но если покопаться в спецификации, окажется, что благодаря ним можно подвезти отдельную сборку для современных браузеров.

                Под катом рассказ о том, как я смог уменьшить размер приложения на 11% без ущерба для старых браузеров и своих нервов.", @"Особенности ES6 Modules

                ES6 Modules — это всем уже известная и широко используемая модульная система.
                Для использования этой модульной системы в браузерах необходимо добавить тип module к каждому скрипт-тегу. Старые браузеры увидят, что тип отличается от text/javascript, и не станут исполнять файл как JavaScript.
                В спецификации еще есть атрибут nomodule для скрипт-тегов. Браузеры, поддерживающие ES6 Modules, проигнорируют этот скрипт, а старые браузеры скачают его и выполнят.Получается, можно просто сделать две сборки: первая с типом module для современных браузеров (Modern Build), а другая — с nomodule для старых (Fallback build).
                Зачем это нужно

                Прежде чем отправить проект в production, мы должны:

                Добавить полифилы.
                Транспилировать современный код в более старый.

                В своих проектах я стараюсь поддерживать максимальное количество браузеров, иногда даже IE 10. Поэтому мой список полифилов состоит в том числе и из таких базовых вещей, как es6.promise, es6.object.values и т.п. Но браузеры с поддержкой ES6 Modules имеют все ES6 методы, и им не нужны лишние килобайты полифилов.

                Транспиляция тоже оставляет заметный след на размере файлов: для покрытия большинства браузеров babel/preset-env использует 25 трансформаторов, каждый из которых увеличивает размер кода. В это же время для браузеров с поддержкой ES6 Modules количество трансформаторов уменьшается до 9.

                Значит, в сборке для современных браузеров мы можем убрать ненужные полифилы и уменьшить количество трансформаторов, что сильно скажется на размере итоговых файлов!", "Делаем Modern Build", 1 },
                    { 5, new DateTime(2018, 12, 23, 12, 8, 52, 515, DateTimeKind.Local), "https://habrastorage.org/webt/au/vq/2d/auvq2dwy-nnfmfigswo_nxrw-ae.jpeg", @"Я дизайнер интерфейсов, и когда меня бесят вещи, я рисую им новый интерфейс. Обычно это никак не влияет на проблему, но становится легче.
                Так вот, однажды мне подарили читалку.", @"Учитывать медленный экран

                Интерфейс для ридера делать сложно, потому что e-ink экран (и начинка читалки) реагируют болезненно медлено. По ощущениям, отклик читалки в 3-4 раза дольше, чем у смартфона.

                От всех сложных жестов и анимаций надо избавляться, насколько это возможно.

                Например, размер текста увеличивается, если поставить два пальца на читалку и развести. Это работает с фотками, но установить 13 размер кегля вместо 12 таким образом невозможно, а жест распознается случайно в 100% случаев.

                Подсказывать следующий шаг

                Я заметила, что когда я уже начала книгу, я читаю каждый день (и ночь) и все хорошо. Самое проблемное место — промежуток между книгами. Между окончанием одной и началом новой может пройти несколько недель или месяцев.

                Это выпадение — проблемный момент, и читателя там нужно ловить.

                На последней странице показываем непрочитанные книги того же автора, книги похожего жанра, книги из той же папки. Хоть какие-нибудь книги.

                Правда непонятно где показывать этот блок: часто в книгах после основного содержания идут примечания или оглавления. То есть книга фактически прочитана, но до конца еще 50 страниц.

                Круто бы распознавать начало примечаний и показывать всю обвязку именно в конце текста, а не в конце книги.

                Букмейт раньше просто спрашивал отзыв о книге на 98% книги. Но решение не очень красивое, потому что там самая драма, а тут какие-то попапы. Сейчас они спрашивают после последней страницы. В телефоне легко промотать до 100%, читалка тач жесты обрабатывает неприятно. На самом деле, кажется что система могла бы распознавать заголовок «примечания».

                Показать статистику

                В этом месяце вы прочитали 17 страниц — могла бы увидеть я на экране своей читалки, устыдиться, и начать читать. Но покетбук не собирает статистику (или собирает, но не показывает). Киндл собирает какую-то дурацкую статистику, но хоть что-то. А ведь мы можем собирать нереально крутые факты! Например, как отличается скорость чтения у книг с жанром научпоп и любовные романы. Какую книгу я перечитывала больше всего раз. В какой день недели я обычно читаю больше.

                Упростить навигацию

                Сейчас навигация устроена так: на главной странице видно несколько последних прочитанных и загруженных книг. А в библиотеке книги показываются списком, где их можно сортировать по нескольким параметрам.

                Добавить полезную информацию про книги

                Про книгу можно показывать что-то поинтереснее, чем вес в килобайтах. Например: «В книге 334 страницы, вы потратите на чтение примерно 4 часа» или «Вы прочитали 45% книги, на оставшиеся 64 страницы уйдет 50 минут».", "Что должна сделать читалка, чтобы вы читали больше?", 1 },
                    { 6, new DateTime(2018, 12, 23, 12, 8, 52, 515, DateTimeKind.Local), "https://habrastorage.org/webt/jh/iw/l-/jhiwl-y02cm4bhppsrj9flbpqsi.png", "Связующее звено сегодняшней статьи отличается от обычного. Это не один проект, для которого был проведён анализ исходного кода, а ряд срабатываний одного и того же диагностического правила в нескольких разных проектах. В чём здесь интерес? В том, что некоторые из рассмотренных фрагментов кода содержат ошибки, воспроизводимые при работе с приложением, а другие – и вовсе уязвимости (CVE). Кроме того, в конце статьи немного порассуждаем на тему дефектов безопасности.", @"Краткое предисловие

                Все ошибки, которые будут рассмотрены сегодня в статье, имеют схожий паттерн:

                программа принимает данные из потока stdin;
                выполняется проверка успешности считывания данных;
                если данные считаны успешно, из строки удаляется символ переноса.

                Тем не менее, все фрагменты, которые будут рассмотрены, содержат в себе ошибки и уязвимы к подстроенному вводу. Так как данные принимаются от пользователя, который и может нарушить логику исполнения приложения, был велик соблазн попробовать что-нибудь сломать. Что я и сделал.

                Все проблемы, приведённые ниже, были обнаружены статическим анализатором PVS-Studio, который ищет ошибки в коде не только для C, C++, но и для C#, Java.

                Конечно, найти проблему статическим анализатором – хорошо, но найти и воспроизвести – это уже совершенно другой уровень удовольствия. :)", "Стреляем в ногу, обрабатывая входные данные", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
