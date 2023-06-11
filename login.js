
function registerUser(event) {
    event.preventDefault();

    const username = document.getElementById("regusername").value;
    const email = document.getElementById("regemail").value;
    const password = document.getElementById("regpassword").value;
    fetch("https://localhost:7024/api/User/register", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            name: username,
            email: email,
            password: password
        })

    })
        .then(response => response.json())
        .then(data => {
            console.log(data); // Process the response data
        })
        .catch(error => {
            console.error("Error:", error);
        });
}

function deleteUser(id) {
    document.getElementById("jobPostings").innerHTML = ""
    fetch(`https://localhost:7024/api/User/del?id=${id}`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log(data); // Process the response data
        })
        .catch(error => {
            console.error("Error:", error);
        });
    loadUser()
}

function loadUser() {
    let Users = [];

    fetch('https://localhost:7024/api/User')
        .then(response => response.json())
        .then(data => {
            Users = [...data];
            const tableBody = document.getElementById("jobPostings");
            console.log('Users', Users);
            Users.forEach((user) => {
                tableBody.innerHTML += `<tr><td>${user.id}</td><td>${user.name}</td><td>${user.email}</td><td>${user.password}</td><td ><button type="submit" class="btn btn-primary" onclick="deleteUser(${user.id})">Dell</button></td><td ><button type="submit" class="btn btn-primary" onclick="updateUser(${user.id})">Update</button></td></tr>`;
            });
        });
}

function gizle() {
    var div = document.getElementById("gizlilik");
    div.style.display = "none";
}
function goster() {
    var div = document.getElementById("gizlilik");
    div.style.display = "block";
}

loadUser()




function updateUser(id) {
    let username = document.getElementById("regusername").value;
    let email = document.getElementById("regemail").value;
    let password = document.getElementById("regpassword").value;
    fetch(`https://localhost:7024/api/User/update?id=${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ name: username, email: email, password: password })
    })
        .then(res => res.json())
        .then(data => {
            alert("Success");
            document.getElementById("tabloBody").innerHTML = "";
            loadUser();
        })
        .catch(err => console.log(err));
}



