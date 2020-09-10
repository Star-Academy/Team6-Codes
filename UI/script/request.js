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
    let template = '';
    template += `
        <div id="page-title">
            <h2>Search Results</h2>
        </div>`;

    docs.forEach(element => {
        template += `
        <div class="result">
        <div style="height: 50px;">
            <img class="doc-image" src="./assets/image/doc-icon.png" >
            <div class="id">
                <p style="margin-left: 5px;">
                    ${element.id}
                </p>
            </div>
        </div>
        <p class="content">
            ${element.content}
        </p>
    </div>`
    });
    document.getElementsByClassName("resultBody")[0].innerHTML = template;
}