let datasetVetor = [];

let dataPontoMedio = [];
let dataRiemmanEsquerda = [];
let dataRiemmanDireita = [];
let dataTrapezio = [];
let dataSimpson13 = [];
let dataSimpson38 = [];

if (listaPontoMedio.length > 0) {
  let listaPontoMedioDecimal = listaPontoMedio.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
  
  for (let i = 0; i < listaPontoMedioDecimal.length; i++) {
    dataPontoMedio.push({ x: inferior + (i * passo), y: listaPontoMedioDecimal[i] });
  }

  let datasetPontoMedio = {
    label: 'Ponto Médio',
    data: dataPontoMedio,
    fill: false,
    borderColor: 'rgb(75, 192, 192)',
    tension: 0.1,
    borderWidth: 1
  }
  datasetVetor.push(datasetPontoMedio);
}

if (listaRiemmanEsquerda.length > 0) {
  let listaRiemmanEsquerdaDecimal = listaRiemmanEsquerda.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
  
  for (let i = 0; i < listaRiemmanEsquerdaDecimal.length; i++) {
    dataRiemmanEsquerda.push({ x: inferior + (i * passo), y: listaRiemmanEsquerdaDecimal[i] });
  }

  let datasetRiemmanEsquerda = {
    label: 'Riemman Esquerda',
    data: dataRiemmanEsquerda,
    fill: false,
    borderColor: 'rgb(1, 2, 192)',
    tension: 0.1,
    borderWidth: 1

  }
  datasetVetor.push(datasetRiemmanEsquerda);
}

if (listaRiemmanDireita.length > 0) {
  let listaRiemmanDireitaDecimal = listaRiemmanDireita.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
  
  for (let i = 0; i < listaRiemmanDireitaDecimal.length; i++) {
    dataRiemmanDireita.push({ x: inferior + (i * passo), y: listaRiemmanDireitaDecimal[i] });
  }

  let datasetRiemmanDireita = {
    label: 'Riemman Direita',
    data: dataRiemmanDireita,
    fill: false,
    borderColor: 'rgb(255, 192, 0)',
    tension: 0.1,
    borderWidth: 1
  }
  datasetVetor.push(datasetRiemmanDireita);
}

if (listaTrapezio.length > 0) {
  let listaTrapezioDecimal = listaTrapezio.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
  
  for (let i = 0; i < listaTrapezioDecimal.length; i++) {
    dataTrapezio.push({ x: inferior + (i * passo), y: listaTrapezioDecimal[i] });
  }

  let datasetTrapezio = {
    label: 'Trapezio',
    data: dataTrapezio,
    fill: false,
    borderColor: 'rgb(12, 42, 192)',
    tension: 0.1,
    borderWidth: 1
  }
  datasetVetor.push(datasetTrapezio);
}

if (listaSimpson13.length > 0) {
  let listaSimpson13Decimal = listaSimpson13.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));
  
  for (let i = 0; i < listaSimpson13Decimal.length; i++) {
    dataSimpson13.push({ x: inferior + (i * passo), y: listaSimpson13Decimal[i] });
  }

  let datasetSimpson13 = {
    label: 'Simpson13',
    data: dataSimpson13,
    fill: false,
    borderColor: 'rgb(85, 0, 202)',
    tension: 0.1,
    borderWidth: 1
  }

  datasetVetor.push(datasetSimpson13);
}
if (listaSimpson38.length > 0) {

  let listaSimpson38Decimal = listaSimpson38.map(item => parseFloat(parseFloat(item.replace(',', '.')).toFixed(6)));

  for (let i = 0; i < listaSimpson38Decimal.length; i++) {
    dataSimpson38.push({ x: inferior + (i * passo), y: listaSimpson38Decimal[i] });
  }

  let datasetSimpson38 = {
    label: 'Simpson38',
    data: dataSimpson38,
    fill: false,
    borderColor: 'rgb(133, 4, 133)',
    tension: 0.1,
    borderWidth: 1
  }
  datasetVetor.push(datasetSimpson38);
}

const ctx = document.getElementById('myChart');

new Chart(ctx, {
  type: 'line',
  data: {
    datasets: [...datasetVetor]
  },
  options: {
    scales: {
      x: {
        type: 'linear',
        beginAtZero: false,
        ticks: {
          stepSize: passo,
        }
      },
      y: {
        beginAtZero: false,
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
        if(Object.keys(dataPontoMedio).length > input.value){
        divzinha.innerText = dataPontoMedio[input.value].y
        }
        else{
          divzinha.innerText = 'N/A';
        }
        break;
      case 2:
        if(divzinha != null){
          if (Object.keys(dataTrapezio).length > 0) {
            divzinha.innerText = dataTrapezio[input.value].y;
          }
        }
        break;
      case 3:
        if(divzinha != null){
          if (Object.keys(dataSimpson13).length > 0) {
            divzinha.innerText = dataSimpson13[input.value].y;
          }
        }
        break;
      case 4:
        if(divzinha != null){
          if (Object.keys(dataSimpson38).length > 0) {
            divzinha.innerText = dataSimpson38[input.value].y
          }
        }
        break;
      case 5:
        if(divzinha != null){
          if (Object.keys(dataRiemmanEsquerda).length > input.value) {
            divzinha.innerText = dataRiemmanEsquerda[input.value].y;
          }
          else{
            divzinha.innerText = 'N/A';
          }
        }
        break;
      case 6:
        if(divzinha != null){
          if (Object.keys(dataRiemmanDireita).length > input.value) {
            divzinha.innerText = dataRiemmanDireita[input.value].y;
          }
          else{
            divzinha.innerText = 'N/A';
          }
        }
        break;
      default:
        break;
    }
  }
}