//Board loading
document.addEventListener('DOMContentLoaded', function () {
    axios.get("https://localhost:7098/api/Event").then((res) => {
        var calendarEl = document.getElementById('calendar');
        var calendar = new FullCalendar.Calendar(calendarEl, {
            initialView: 'dayGridMonth',
            events: res.data,

        });
        calendar.render();
    });

});

//add event
document.getElementById("addEvent").addEventListener("click", function addEvent() {
    let date = document.getElementById('date');
    let content = document.getElementById('content');
    axios.post('https://localhost:7098/api/Event', {
        "title": content.value,
        "start": date.value
    })
    .then(()=>location.reload());
        
});

//delete event
document.getElementById("deleteEvent").addEventListener("click", beforeDelete);
function beforeDelete() {
    axios.get("https://localhost:7098/api/Event").then(function (res) {
        const eventArr = res.data;
        document.getElementById("eventList").innerHTML = "<ul id='myList'></ul>";

        for (let index = 0; index < eventArr.length; index++) {
            document.getElementById("myList").innerHTML += "<li id=" + index + ">" + eventArr[index].title + "<button id=" + eventArr[index].id + " class='delete-btn'>מחק</button></li>";
        }
        const btnArr = document.getElementsByClassName("delete-btn");
        console.log(btnArr);
        for (let index = 0; index < btnArr.length; index++) {
            btnArr[index].addEventListener("click", () => deleteEvent(btnArr[index].id));

        }

    });
}
function deleteEvent(id) {
    axios.delete("https://localhost:7098/api/Event/" + id).then(()=>location.reload());
}
document.getElementById("updateEvant").addEventListener("click", beforeUpdate);

//Update tasks
function beforeUpdate() {
    axios.get("https://localhost:7098/api/Event").then(function (res) {
        const eventArr = res.data;
        document.getElementById("eventList").innerHTML = "<ul id='myList'></ul>";
        for (let index = 0; index < eventArr.length; index++) {
            document.getElementById("myList").innerHTML += `<li id=${eventArr[index].id} >
              <input type='text' value=${eventArr[index].title}></input>
              <input id="date_${eventArr[index].id}" type='date' value=${eventArr[index].start}>
              <button onclick="updateEvent(${eventArr[index].id} )">עדכן</li>`
        }
    });
}
function updateEvent(id) {
    console.log(id);
    let eventForUpdate = document.getElementById(id);
    console.log(eventForUpdate);
    const title = document.querySelector(`li[id="${id}"] > input[type=text]`).value;
    const date = document.querySelector(`li[id="${id}"]> input[type=date]`).value;
    console.log(title);
    console.log(date);
    axios.put(`https://localhost:7098/api/Event/${id}`, {
        "title": title,
        "start": date
    }).then(()=>location.reload());

}