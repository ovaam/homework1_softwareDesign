# homework1_softwareDesign
# Отчет по проекту "Кр1" Маловой Олеси бпи238

## Общая идея решения

Основной функционал включает:

1. **Создание, редактирование и удаление счетов, категорий и операций**.
2. **Расчет разницы между доходами и расходами за выбранный период**.
3. **Пересчет баланса счетов на основе операций**.

---

## Принципы SOLID и GRASP

### Принципы SOLID

1. **Single Responsibility Principle (Принцип единственной ответственности)**:
   - Каждый класс отвечает за одну задачу. Например:
     - `BankAccountFacade` отвечает за управление счетами.
     - `CategoryFacade` отвечает за управление категориями.
     - `OperationFacade` отвечает за управление операциями.
   - Это упрощает поддержку и тестирование кода.

2. **Open/Closed Principle (Принцип открытости/закрытости)**:
   - Классы открыты для расширения, но закрыты для модификации. Например:
     - Если потребуется добавить новый тип операции, можно создать новый класс, не изменяя существующий код.
     - Фасады (`BankAccountFacade`, `CategoryFacade`, `OperationFacade`) могут быть расширены без изменения их основной логики.

3. **Liskov Substitution Principle (Принцип подстановки Барбары Лисков)**:
   - Наследники могут использоваться вместо базовых классов. Например:
     - Если в будущем будет создан новый тип счета, он сможет заменить базовый класс `BankAccount` без изменения логики программы.

4. **Interface Segregation Principle (Принцип разделения интерфейса)**:
   - Интерфейсы (`IDataService`, `IDataImporter`) разделены на мелкие части, чтобы клиенты не зависели от методов, которые они не используют.

5. **Dependency Inversion Principle (Принцип инверсии зависимостей)**:
   - Зависимости строятся на абстракциях, а не на конкретных реализациях. Например:
     - `JsonDataImporter` зависит от интерфейса `IDataService`, а не от конкретной реализации `DataService`.

### Принципы GRASP

1. **High Cohesion (Высокая связность)**:
   - Классы имеют высокую связность, так как каждая сущность (счет, категория, операция) инкапсулирует свою логику. Например:
     - `BankAccountFacade` содержит только методы для работы со счетами.
     - `CategoryFacade` содержит только методы для работы с категориями.

2. **Low Coupling (Низкая связанность)**:
   - Классы слабо связаны между собой. Например:
     - `BankAccountFacade` не зависит от `CategoryFacade` или `OperationFacade`.
     - Зависимости между классами управляются через DI-контейнер.

---

## Паттерны GoF

### 1. **Фасад (Facade)**
- **Описание**: Паттерн "Фасад" используется для упрощения взаимодействия с подсистемой, предоставляя простой интерфейс для выполнения сложных операций.
- **Реализация**: В проекте фасады (`BankAccountFacade`, `CategoryFacade`, `OperationFacade`) используются для объединения методов, связанных с управлением счетами, категориями и операциями.
- **Важность**: Фасады упрощают взаимодействие с системой, скрывая сложность внутренней логики.

### 2. **Команда (Command)**
- **Описание**: Паттерн "Команда" инкапсулирует запрос как объект, позволяя параметризовать клиентов с различными запросами.
- **Реализация**: В проекте каждая операция (создание счета, категории, операции) может быть представлена как команда.
- **Важность**: Паттерн позволяет легко добавлять новые команды и управлять ими.

### 3. **Декоратор (Decorator)**
- **Описание**: Паттерн "Декоратор" позволяет динамически добавлять поведение объектам.
- **Реализация**: В проекте декоратор может быть использован для добавления логирования или измерения времени выполнения операций.
- **Важность**: Декоратор позволяет добавлять новую функциональность без изменения существующего кода.

### 4. **Фабрика (Factory)**
- **Описание**: Паттерн "Фабрика" используется для создания объектов без указания их конкретных классов.
- **Реализация**: В проекте фабрика может быть использована для создания доменных объектов (счетов, категорий, операций) с валидацией.
- **Важность**: Фабрика централизует логику создания объектов, что упрощает поддержку и тестирование.

### 5. **Прокси (Proxy)**
- **Описание**: Паттерн "Прокси" предоставляет суррогатный объект для управления доступом к другому объекту.
- **Реализация**: В проекте прокси может быть использован для кэширования данных в памяти, чтобы уменьшить количество обращений к базе данных.
- **Важность**: Прокси улучшает производительность за счет кэширования и управления доступом к данным.

---

## Инструкция по запуску

1. Склонируйте репозиторий с проектом.
2. Выполните команды `dotnet add package Microsoft.Extensions.DependencyInjection` и `dotnet add package Newtonsoft.Json`
3. Перейдите в папку с проектом и выполните команду `dotnet run`.
4. Следуйте инструкциям в консоли для взаимодействия.

---
