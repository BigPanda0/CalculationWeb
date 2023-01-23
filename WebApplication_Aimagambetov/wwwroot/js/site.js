
let arr = [];
let arr2 = [];
let arr3 = [];
let arr4 = [];

for (let i = 0; i < document.getElementById("1").getElementsByTagName("td").length; i++) {
    arr.push(document.getElementById("1").getElementsByTagName("td")[i].textContent)
}
for (let i = 0; i < document.getElementById("2").getElementsByTagName("td").length; i++) {
    arr2.push(document.getElementById("2").getElementsByTagName("td")[i].textContent)
}
for (let i = 0; i < document.getElementById("3").getElementsByTagName("td").length; i++) {
    arr3.push(document.getElementById("3").getElementsByTagName("td")[i].textContent)
}
for (let i = 0; i < document.getElementById("4").getElementsByTagName("td").length; i++) {
    arr4.push(document.getElementById("4").getElementsByTagName("td")[i].textContent)
}
const data = {
    labels: arr4,
    datasets: [{
        label: 't',
        backgroundColor: 'blue',
        borderColor: 'blue',
        data: arr,
    },
    {
        label: 'T',
        backgroundColor: 'red',
        borderColor: 'red',
        data: arr2,
    }]
};

const config = {
    type: 'line',
    data: data,
    options: {
        scales: {
            x: {
                display: true,
                title: {
                    display: true,
                    text: 'Координаты у, м'
                }
            },
            y: {
                display: true,
                title: {
                    display: true,
                    text: 'Температура, °С'
                }
            }
        }
    }
};

const myChart = new Chart(
    document.getElementById('myChart'),
    config
);



const data2 = {
    labels: arr4,
    datasets: [{
        label: 'Разность температур, °С',
        backgroundColor: 'blue',
        borderColor: 'blue',
        data: arr3,
    }]
};

const config2 = {
    type: 'line',
    data: data2,
    options: {
        scales: {
            x: {
                display: true,
                title: {
                    display: true,
                    text: 'Координаты у, м'
                }
            },
            y: {
                display: true,
                title: {
                    display: true,
                    text: 'Разность температур, °С'
                }
            }
        }
    }
};

const myChart2 = new Chart(
    document.getElementById('myChart2'),
    config2
);

