# MARVEL COMIC LIST

## VỀ PROJECT

Marvel Comic List là một dự án cá nhân cho môn học Project 1 với đề tài tìm hiểu về ASP.NET MVC và API để xây dựng Web App sử dụng các public API. Marvel Comic List là một trang thông tin tìm kiếm thông tin các nhân vật, bộ truyện tranh từ cơ sở dữ liệu của [Marvel Comic](https://www.marvel.com/). Phục vụ người đọc có thể tra cứu dễ dàng các đầu truyện có nhân vật yêu thích xuất hiện, hay tổng hợp những nhân vật có xuất hiện trong các đầu truyện.

## VỀ MARVEL COMICS API

Marvel Comics API là một công cụ tuyệt vời giúp cho lập trình viên trên khắp thế giới có thể tạo ra những Website, ứng dụng kỳ lạ và sáng tạo thông qua việc cung cấp dữ liệu trong hơn 70 năm thành lập và phát triển của Marvel Comics.

Marvel Comics API là một RESTful service cung cấp những phương thức cho phép truy cập các tài nguyên khác nhau và cho phép lọc, tìm kiếm những bộ dữ liệu với nhiều trường thông tin. Tất cả đều được biểu diễn những JSON object. Hiện tại, lập trình viên có thể truy cập 6 loại dữ liệu khác nhau, bao gồm:  

1. **Characters:**  Toàn bộ các nhân vật, sinh vật được xuất hiện trong vũ trụ Marvel, cũng như những vũ trụ, dòng thời gian song song khác.  
2. **Comics:**  Những ấn bản, tập truyện được phát hành bản giấy hay sách điện tử.  
3. **Comic series:**  Những bộ truyện bao gồm nhiều tập truyện nhỏ hơn có cùng tên và được đánh số lần lượt.  
4. **Comic stories:**  Những câu chuyện bao gồm một hay nhiều tập truyện, được sử dụng lại từ những bộ truyện khác nhau để kể một câu chuyện liền mạch về nội dụng.  
5. **Comic events and crossovers:**  Những câu chuyện rất lớn, liên kết nhiều bộ truyện lại với nhau.  
6. **Creators:**  Tất cả những tác giả, thành viên tham gia trong quá trình sản xuất nội dung, ấn bản của tập truyện hay bộ truyện.

## DOCKERIZE PROJECT TO HEROKU

Step 1. Login Heroku

```shell
heroku container:login
```  

Step 2. Build project with Docker

```shell
# 'YourAppName' should be the name of the app on Docker
docker build -t YourAppName .
```  

Step 3. Push docker image to Heroku

```shell
# 'YourAppName' should be the name of the app you set on Heroku
heroku container:push -a YourAppName web
```  

Step 4. Publish web application

```shell
# 'YourAppName' should be the name of the app you set on Heroku
heroku container:release -a YourAppName web
```  
