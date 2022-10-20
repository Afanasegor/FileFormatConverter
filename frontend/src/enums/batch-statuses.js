const Statuses = {
    Created: 0,
    InProcessing: 1,
    Error: 2,
    Completed: 3,
}

const StatusesNumberToString = {
    0: "Создано",
    1: "В процессе",
    2: "Ошибка",
    3: "Готово"
}

export default {
    Statuses,
    StatusesNumberToString
}