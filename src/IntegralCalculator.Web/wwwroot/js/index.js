// lista = JSON.parse(localStorage.getItem('lista'));
// lista = Json.parse(lista);
let listaPontoMedioDecimal = listaPontoMedio.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
let listaRiemmanEsquerdaDecimal = listaRiemmanEsquerda.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
let listaRiemmanDireitaDecimal = listaRiemmanDireita.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
let listaTrapezioDecimal = listaTrapezio.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
let listaSimpson13Decimal = listaSimpson13.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
let listaSimpson38Decimal = listaSimpson38.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
// let listaDecimal = lista.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
// let listaDecimal = lista.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
// let listaDecimal = lista.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
// console.log(listaDecimal);

const ctx = document.getElementById('myChart');

let dataPontoMedio = [];
for (let i = 0; i < listaPontoMedioDecimal.length; i++) {
  dataPontoMedio.push({ x: i * passo, y: listaPontoMedioDecimal[i] });
}
let dataRiemmanEsquerda = [];
for (let i = 0; i < listaRiemmanEsquerdaDecimal.length; i++) {
  dataRiemmanEsquerda.push({ x: i * passo, y: listaRiemmanEsquerdaDecimal[i] });
}
let dataRiemmanDireita = [];
for (let i = 0; i < listaRiemmanDireitaDecimal.length; i++) {
  dataRiemmanDireita.push({ x: i * passo, y: listaRiemmanDireitaDecimal[i] });
}
let dataTrapezio = [];
for (let i = 0; i < listaTrapezioDecimal.length; i++) {
  dataTrapezio.push({ x: i * passo, y: listaTrapezioDecimal[i] });
}
let dataSimpson13 = [];
for (let i = 0; i < listaSimpson13Decimal.length; i++) {
  dataSimpson13.push({ x: i * passo, y: listaSimpson13Decimal[i] });
}
let dataSimpson38 = [];
for (let i = 0; i < listaSimpson38Decimal.length; i++) {
  dataSimpson38.push({ x: i * passo, y: listaSimpson38Decimal[i] });
}
console.log(dataTrapezio)

// PontoMedio
new Chart(ctx, {
  type: 'line',
  data: {
    datasets: [{
      label: 'Médio',
      data: dataPontoMedio,
      fill: false,
      borderColor: 'rgb(75, 192, 192)',
      tension: 0,
      borderWidth: 1
    },
    {
      label: 'Trapezio',
      data: dataTrapezio,
      fill: false,
      borderColor: 'rgb(12, 42, 192)',
      tension: 0,
      borderWidth: 1
    },
    {
      label: 'Simpson13',
      data: dataSimpson13,
      fill: false,
      borderColor: 'rgb(85, 0, 202)',
      tension: 0,
      borderWidth: 1
    },
    {
      label: 'Simpson38',
      data: dataSimpson38,
      fill: false,
      borderColor: 'rgb(133, 4, 133)',
      tension: 0,
      borderWidth: 1
    },
    {
      label: 'Riemman Esquerda',
      data: dataRiemmanEsquerda,
      fill: false,
      borderColor: 'rgb(1, 2, 192)',
      tension: 0,
      borderWidth: 1
    },
    {
      label: 'Riemman Direita',
      data: dataRiemmanDireita,
      fill: false,
      borderColor: 'rgb(255, 192, 0)',
      tension: 0,
      borderWidth: 1
    }
    ]
  },
  options: {
    scales: {
      x: {
        type: 'linear',
        beginAtZero: true,
        ticks: {
          stepSize: passo,
        }
      },
      y: {
        beginAtZero: true,
        ticks: {
          stepSize: 1
        }
      }
    },
    plugins: {
      tooltip: {
        callbacks: {
          label: function (context) {
            let labelPontoMedio = context.dataset.labelPontoMedio || '';

            if (labelPontoMedio) {
              labelPontoMedio += ': ';
            }
            if (context.parsed.y !== null) {
              labelPontoMedio += context.parsed.y.toFixed(6);
            }
            return labelPontoMedio;
          }
        }
      }
    }
  }
});



function parseValue(input) {
  for (let i = 1; i <= 6; i++) {
    let divzinha = document.querySelector('#display-' + i);
    switch (i) {
      case 1:
        divzinha.innerText = dataPontoMedio[input.value].y
        break;
      case 2:
        if (Object.keys(dataPontoMedio).length > 0) {
          divzinha.innerText = dataTrapezio[input.value].y;
        }
        break;
      case 3:
        if (Object.keys(dataSimpson13).length > 0) {
          divzinha.innerText = dataSimpson13[input.value].y;
        }
        break;
      case 4:
        if (Object.keys(dataSimpson38).length > 0) {
          divzinha.innerText = dataSimpson38[input.value].y
          console.log(dataSimpson38)
        }
        break;
      case 5:
        if (Object.keys(dataRiemmanEsquerda).length > 0) {
          divzinha.innerText = dataRiemmanEsquerda[input.value].y;
        }
        break;
      case 6:
        if (Object.keys(dataRiemmanDireita).length > 0) {
          divzinha.innerText = dataRiemmanDireita[input.value].y;
        }
          break;
      default:
        break;
    }
  }
}