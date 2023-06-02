# ASPNET_House_Rental
asp.net房屋出租房源网响应式网站设计毕业源码案例设计
## 开发软件: Visual Studio 2010以上    数据库：sqlserver2005以上
## 开发技术：基于MVC思想和三层设计模式，前台采用bootstrap响应式框架，后台div+css

房屋管理模块，管理员也就是他是管理平台所有的信息。只是负责维护运行租赁网站，不参与直接的租赁业务。
其中管理员的功能包括：用户管理，房源管理，房屋类型管理，户型管理，装修程度管理，新闻留言管理，新闻公告管理，客户信息管理。
用户管理模块，是便于管理员了解当前几个大客户的情况。
用户主要是发布房源信息，查看房源，以及收藏房源。
## 实体ER属性：
用户: 用户名,登录密码,姓名,性别,出生日期,用户照片,联系电话,邮箱,家庭地址,注册时间

房源: 房源id,房源名城,租金(元/月),房源图片,户型,面积,类型,朝向,楼层,装修,要求,小区,房屋配套,房源概况,联系电话,联系人

房屋类型: 类型id,类型名称

户型: 户型id,户型名称

装修程度: 装修程度id,装修程度

留言: 留言id,留言标题,留言内容,留言人,留言时间,管理回复,回复时间

新闻公告: 公告id,标题,公告内容,发布时间