
var cloakSpan = document.getElementById("cloackCounter");
var stoneSpan = document.getElementById("stoneCounter");
var wandSpan = document.getElementById("wandCounter");

// Create connection
var connectionDeathlyHallows = new signalR.HubConnectionBuilder()
    //.configureLoggings(sirnalR.LogLevel.Information)
    .withUrl("/hubs/deathlyhallows").build();

// Connect to methods that hub invokes aka receive notifications from hub
connectionDeathlyHallows.on("updateDeathlyHallowCount", (cloak, stone, wand) => {
    cloakSpan.innerText = cloak.toString();
    stoneSpan.innerText = stone.toString();
    wandSpan.innerText = wand.toString();
})

// Invoke hub methids aka send notification to hub
function newWindowLoadedOnClient() {
    connectionUserCount.invoke("NewWindowLoaded", "Anna").then((value) => console.log(value));
}

// Start connection
function fulfilled() {
    // do something on start
    console.log("Connection to User Hub Successful");
}
function rejected() {
    // rejected logs
}

connectionDeathlyHallows.start().then(fulfilled, rejected);
