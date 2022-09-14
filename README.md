# dotnetlean

dotnet 教學基礎專案應用範例

<h2>CourseWpfApp</h2>

WPF+ADO.NET+MS-SQL 範例專案，其中已實作＂管理員帳號管理＂，＂開課資料管理＂，其餘功能皆可以參考前二者實作程式碼，同學可自行完成作品。
資料庫Schema請參考教材內容。

* 管理員帳號管理
1. 密碼必須以Hash⽅式寫入資料庫
2. 系統⾄少要有⼀位管理帳號不得刪除
3. 系統上的功能必須經過登入後才能使⽤
4. 登入的管理員可以修改⾃已的密碼
5. 帳號不能重覆

* 學員資料管理
1. 具有學員基本資料的新增／修改／刪除／查詢功能
2. 可以查詢學員的基本資料及選課資料
3. 已有選課記錄的學員資料不得刪除
4. email做為登入帳號，故不能重覆
5. 預設密碼123456
6. 密碼採⽤hash寫入資料庫，hash時以學員id(⼤寫)做為加鹽處理

* 講師資料管理
1. 具有講師基本資料的新增／修改／刪除／查詢功能
2. 可以查詢講師的基本資料及開課資料
3. 已有開課記錄的講師資料不得刪除
4. email做為登入帳號，故不能重覆
5. 預設密碼123456
6. 密碼採⽤hash寫入資料庫，hash時以學員id(⼤寫)做為加鹽處理

* 課程資料管理
1. 具有課程基本資料的新增／修改／刪除／查詢功能
2. 已有開課記錄的課程資料不得刪除

* 開課資料管理
1. 具有開課記錄的新增／修改／刪除／查詢功能
2. 已有學員選課記錄的開課資料不得刪除

<h2>StuImage — 學員實作成品</h2>