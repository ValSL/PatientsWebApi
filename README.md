# Инстукция

1. Склонируйте репозиторий.
2. Перейдите в директорию `\PatientsWebApi\PatientsWebApi` с файлом `docker-compose`.
3. Запустите `docker-compose up`.
4. Дождитесь окончательныйх запусков двух сервисов - БД и api-приложения
5. В директории `\PatientsWebApi\GeneratorApp` запустите приложение `PatientsGenerator.exe` для заполнения базы данных.
6. В директории `\PatientsWebApi` найдите файл `requests.json`, это коллекция запросов для Postman. Используйте его, чтобы добавить коллекцию себе в Postman.
7. Делаете запросы, смотрите ответы.

# Небольшое пояснение
Многие моменты не доделаны до конца в виду отсутствия времени.
Например, валидация сделана только для "Создания пациента".
Также нету мапинга DTO моделей ни в одном ендпоинте, в итоге возвращается слегка перегруженный результат.
Не все возможные ошибки обработаны.
