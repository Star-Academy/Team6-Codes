var datas = [];
function search() {
    let searchTextElement = document.getElementById('queryValue');
    let xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            displayResult(this.response);
        }
    };
    xhttp.open("GET", `https://localhost:5001/Search/Search?query=${searchTextElement.value}`, true);
    xhttp.responseType = 'json';
    xhttp.send();
}

function displayResult(docs) {
    location.href = "./result.html";
    document = "./result.html"
    
    let template = '';
    docs.forEach(element => {
        template += `
        <img id="doc-icon" src="./assets/-icon.png">
        <h3 class="id">
            ${element.id}
        </h3>

        <p class="content">
            ${element.content}
        </p>`
    });
    document.getElementsByClassName("result")[0].innerHTML = template;



}