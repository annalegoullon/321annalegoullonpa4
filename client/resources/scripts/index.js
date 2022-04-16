const url = "https://localhost:7090/api/Song";
var songList= [];
var mySong={};
function findSongs(){
   
    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
    }).then(function(json) {
        document.getElementById("cards").innerHTML = "";
    var songs = json;
    for(let i = 0; i < songs.length;i++){
        const card = document.createElement('div');
        card.className = "card col-md-4 bg-dark text-white";
        card.innerHTML = `
            <img src="./resources/images/music.jpeg" class="card-img" alt="..."/>
            <div class="card-img-overlay">
            <h5 class="card-title">${songs[i].songTitle} || Favorited? ${songs[i].favorited}</h5>
            </div>
            `
        document.getElementById("cards").appendChild(card);
    }
        }).catch(function(error){
            console.log(error);
        })

}

    

postSong = () =>{
    let searchString = document.getElementById("title").value;
    const putSongApiUrl = url;
    
    //addSongApiUrl += songTitle;
    
    
    fetch(putSongApiUrl,{
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            songTitle:searchString,
            songTimestamp: new Date().toISOString(),
            deleted: "n",
            favorited: "n"
        })
    })
    .then((res) => res.text())
    .then((json) => {
        console.log(json)
        let html = ``;

        console.log(song.title)
        const card = document.createElement('div');
        card.className = "card col-md-4 bg-dark text-white";
        card.innerHTML = `
            <img src="./resources/images/music.jpeg" class="card-img" alt="..."/>
            <div class="card-img-overlay">
                <h5 class="card-title">${searchString}</h5>
            </div>
        `
        document.getElementById("cards").appendChild(card);
        }).catch(function(error){
            console.log(error);
        }).finally(() => {
            findSongs();
        });
    }
    

function deleteSong() {
    let searchString = document.getElementById("deleteid").value;
    console.log(searchString);
    const deleteSongUrl = url;
    console.log(deleteSongUrl);
    
    fetch(deleteSongUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify({
            songTitle: searchString,
            songTimeStamp: new Date().toISOString(),
            deleted: "y",
            favorited: "n" 
        })
    })
        .then((response) => {
            console.log(response);
            findSongs();
        });
}
function favoriteSong(){
    let searchString = document.getElementById("favoriteid").value;
    console.log(searchString);
    const favSongUrl = url;
    console.log(favSongUrl);

    fetch(favSongUrl,{
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            songTitle:searchString,
            songTimestamp: new Date().toISOString(),
            deleted: "n",
            favorited: "y"
        })
    })
    .then((response) => {
        console.log(response);
        findSongs();
    });


    
}

// function findSongs(){
    
//    var url = "https://www.songsterr.com/a/ra/songs.json?pattern="

//     var url = "https://localhost:7090/api/Song";
//     let searchString = document.getElementById("searchSong").value;

//     url += searchString;

//     console.log(searchString)

//     fetch(url).then(function(response) {
// 		console.log(response);
// 		return response.json();
// 	}).then(function(json) {
//         console.log(json)
//         let html = ``;
// 		json.forEach((song) => {
//             console.log(song.SongTitle)
//             html += `<div class="card col-md-4 bg-dark text-white">`;
// 			html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
// 			html += `<div class="card-img-overlay">`;
// 			html += `<h5 class="card-title">`+song.SongTitle+`</h5>`;
//             html += `</div>`;
//             html += `</div>`;
// 		});
		
//         if(html === ``){
//             html = "No Songs found :("
//         }
// 		document.getElementById("searchSongs").innerHTML = html;

// 	}).catch(function(error) {
// 		console.log(error);
// 	})
//}



