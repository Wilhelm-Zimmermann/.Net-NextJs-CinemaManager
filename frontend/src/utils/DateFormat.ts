
const {format: formatDate} = new Intl.DateTimeFormat("pt-BR", 
    {
        year: "numeric", 
        month: "short", 
        day: "numeric"
    });

const {format: formatDateWithHour } = new Intl.DateTimeFormat("pt-BR", 
{
    year: "numeric", 
    month: "short", 
    day: "numeric",
    hour: "numeric",
    minute: "numeric"
});

export { formatDate, formatDateWithHour }