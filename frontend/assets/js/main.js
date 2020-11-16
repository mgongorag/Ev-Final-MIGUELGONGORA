const url = "http://api-ef-gongora.cetcom.edu.gt/api/";
let seleccionado = '';
const btnModalGuardar = document.getElementById('btnModalGuardar').addEventListener('click', () =>{
    document.getElementById('btnActualizar').classList.add('d-none')
    document.getElementById('btnGuardar').classList.remove('d-none')
})

window.onload = ()=>{
    fillDdlContinentes();
}

function fillDdlContinentes() {
    const ddlContinents = document.getElementById('ddlContinentes')
    let html = '<option>Elija un Continente</option>';
    fetch(url + 'GetContinents')
    .then( response => {
        return response.json();
    } )
    .then( continents => {
        continents.forEach(continent => {
            html += `
                    <option value=${continent.IdContinente}>${continent.TxtContinente}</option>
                    `
        });
        ddlContinents.innerHTML = html;
    } )
}


function getCountries(id, country) {
    seleccionado = country;
    document.getElementById('tituloContinente').innerHTML = country;
    fetch(url + 'getCountryByContinent', {
        method: 'POST',
        headers: {
             'Accept': 'application/json',
             'Content-Type': 'application/json'
        },
        body: JSON.stringify({
             "IdContinent": id
        })
   })
    .then( (response) => {
        return response.json();
    })
    .then ( (countries) => {
        console.log(countries, 'table')
        fillTable(countries);
    })
}


function fillTable(countries) {
    const dataTable = document.getElementById('table-body')

    let html = ''

    countries.forEach(country => {
        console.log(country);
        html += `
        <tr>
            <th class="text-center align-middle" scope="row">${country.TxtPais}</th>
            <td class="text-center align-middle">${country.TxtCapital}</td>
            <td class="text-center align-middle">${country.IntAnioIndependencia}</td>
            <td class="text-center align-middle">${country.IntPoblacion}</td>
            <td class="text-center align-middle">${country.TxtPresidenteActual}</td>
            <td class="text-center align-middle">${country.TxtIdiomaOficial}</td>
            <td class="text-center align-middle">${country.TxtMoneda}</td>
            <td class="text-center align-middle"><button onclick="getCountry(${country.IdPais})" data-toggle="modal" data-target="#formModal"  type="button" class="btn btn-outline-info">Editar</button></td>
            <td class="text-center align-middle"><button type="button" onclick="deleteCountry(${country.IdPais})" class="btn btn-outline-danger">Eliminar</button></td>
        </tr>
        `
    });
    dataTable.innerHTML = html;
}

function deleteCountry(id) {
    let alerta = document.getElementById('alert-eliminar');
    fetch(url + 'deleteCountry', {
        method: 'POST',
        headers: {
             'Accept': 'application/json',
             'Content-Type': 'application/json'
        },
        body: JSON.stringify({
             "id": id
        })
   })
   .then(function (response) {
        return response.json();
   })
   .then( (data)=>{
       data = data[0]
       if(data.State){
           alerta.classList.remove('d-none');
           alerta.classList.remove('alert-danger');
           alerta.classList.add('alert-success');
           alerta.innerHTML = data.Message;
           
       }else{
        alerta.classList.remove('d-none');
        alerta.classList.remove('alert-success');
        alerta.classList.add('alert-danger');
        alerta.innerHTML = data.Message;
       }

       setTimeout(() => {
           alerta.classList.add('d-none');
       }, 5000);

       location.reload();
   })
}

function updateCountry(){
    
    let idcontinente,
         idpais,
         pais,
         capital,
         idioma,
         independencia,
         poblacion,
         presidente, 
         moneda;

    idpais= document.getElementById('idPais').value
    idcontinente = document.getElementById('ddlContinentes').value;
    pais = document.getElementById('pais').value;
    capital = document.getElementById('capital').value;
    idioma = document.getElementById('idioma').value;
    independencia = document.getElementById('independencia').value;
    poblacion = document.getElementById('poblacion').value;
    presidente = document.getElementById('presidente').value;
    moneda = document.getElementById('moneda').value;

    fetch(url + 'updateCountry', {
              method: 'POST',
              headers: {
                   'Accept': 'application/json',
                   'Content-Type': 'application/json'
              },
              body: JSON.stringify({
                    "id" : idpais,
                    "idContinent" : idcontinente,
                    "country": pais,
                    "capital": capital,
                    "yearOfIndependence" : independencia,
                    "population": poblacion,
                    "president": presidente,
                    "language": idioma,
                    "coin": moneda
              })
         })

         .then( response => {
              return response.json();
         })
         .then( data => {
             console.log(data);
            let alerta = document.getElementById('alertModal');
            if(data[0].State){
                console.log('fui true')
                alerta.innerHTML =  data[0].Message
                alerta.classList.remove("d-none");
                alerta.classList.remove("alert-danger");
                alerta.classList.add("alert-success");
                document.getElementById('form-agregarPais').reset();
             }else{
                alerta.innerHTML =  data[0].Message
                alerta.classList.remove("d-none");
                alerta.classList.remove("alert-success");
                alerta.classList.add("alert-danger");
             }
            setTimeout(() => {
                alerta.classList.add('d-none');
            }, 5000);
         })


         paises = getCountries(idcontinente, seleccionado);
         fillTable(pais);
}


function getCountry(id) {
    document.getElementById('btnActualizar').classList.remove('d-none');
    document.getElementById('btnGuardar').classList.add('d-none');

    let idcontinente,
         pais,
         capital,
         idioma,
         independencia,
         poblacion,
         presidente, 
         moneda;


    fetch(url + 'getCountryById', {
        method: 'POST',
        headers: {
             'Accept': 'application/json',
             'Content-Type': 'application/json'
        },
        body: JSON.stringify({
             "id": id
        })
   })
    .then( (response) => {
        return response.json();
    })
    .then ( (country) => {
        country = country[0];
        console.log(country);
       idcontinente = country.IdContinente
       pais =country.TxtPais;
       capital = country.TxtCapital;
       idioma =country.TxtIdiomaOficial;
       independencia =country.IntAnioIndependencia;
       poblacion =country.IntPoblacion;
       presidente = country.TxtPresidenteActual;
       moneda = country.TxtMoneda;

        
    document.getElementById('ddlContinentes').value = idcontinente;
    document.getElementById('pais').value = pais;
    document.getElementById('capital').value = capital;
    document.getElementById('idioma').value = idioma;
    document.getElementById('independencia').value = independencia; 
    document.getElementById('poblacion').value = poblacion;
    document.getElementById('presidente').value = presidente;
    document.getElementById('moneda').value = moneda;
    document.getElementById('idPais').value = country.IdPais;
    })

}


  function addCountry() {
    
    let idcontinente,
         pais,
         capital,
         idioma,
         independencia,
         poblacion,
         presidente, 
         moneda;

    idcontinente = document.getElementById('ddlContinentes').value;
    pais = document.getElementById('pais').value;
    capital = document.getElementById('capital').value;
    idioma = document.getElementById('idioma').value;
    independencia = document.getElementById('independencia').value;
    poblacion = document.getElementById('poblacion').value;
    presidente = document.getElementById('presidente').value;
    moneda = document.getElementById('moneda').value;

    fetch(url + 'addCountry', {
              method: 'POST',
              headers: {
                   'Accept': 'application/json',
                   'Content-Type': 'application/json'
              },
              body: JSON.stringify({
                    "idContinent" : idcontinente,
                    "country": pais,
                    "capital": capital,
                    "yearOfIndependence" : independencia,
                    "population": poblacion,
                    "president": presidente,
                    "language": idioma,
                    "coin": moneda
              })
         })

         .then( response => {
              return response.json();
         })
         .then( data => {
             console.log(data);
            let alerta = document.getElementById('alertModal');
            if(data[0].State){
                alerta.innerHTML =  data[0].Message
                alerta.classList.remove("d-none");
                alerta.classList.add("alert-success");
                document.getElementById('form-agregarPais').reset();
                
             }else{
                alerta.innerHTML =  data[0].Message
                alerta.classList.remove("d-none");
                alerta.classList.add("alert-danger");
             }
            setTimeout(() => {
                alerta.classList.add('d-none');
            }, 5000);
         })
}
