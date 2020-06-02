const dotenv = require('dotenv')
const fetch = require("node-fetch")


class DropBoxSolution {
    constructor() {
        dotenv.config()
        this.ACCESS_TOKEN = process.env.DROPBOX_KEY
    }

    CheckAuth () {
        try {
            const request = fetch('https://api.dropboxapi.com/2/users/get_current_account',{
                method: 'POST',
                headers: {  
                    'Authorization': `Bearer ${this.ACCESS_TOKEN}`
                },
            })
            request.then((res) => {
                if(res.status === 200){
                    console.log(`Success: ${res.statusText}`)
                    return 'ok'
                }
                else{
                    console.log(`Error ${res.status}: ${res.statusText}`)
                    return 'err'
                }
            })
        }catch (e) {
            console.log(`Error: ${e}`)
            return 'err'
        }
    }

    AddFolder (name) {
        const data = {
            path: `/${name}`,
            autorename: false
        } 
        const request = fetch('https://api.dropboxapi.com/2/files/create_folder_v2',{
            method: 'POST',
            headers: {  
                'Content-Type': "application/json",
                'Authorization': `Bearer ${this.ACCESS_TOKEN}`
            },
            body: JSON.stringify(data)
        })
        return request.then((res) => {
            if(res.status === 200){
                console.log(`Success: ${res.statusText}`)
                return 'ok'
            }
            else{
                console.log(`Error ${res.status}: ${res.statusText}`)
                return `Error ${res.status}: ${res.statusText}`
            }
        })
        .catch(e => {
            console.log(`Error: ${e}`)
            return 'err'
        })
    }

    async AddFile (folder, name) { 
        const rand = Math.floor(Math.random()*10);
        const data = {
            path: `/${folder}/${name}.png`,
            mode: "add",
            autorename: true,
        }
        const file = await fetch(`https://www.placecage.com/300/30${rand}`).then(res => res.body)
        const request = fetch('https://content.dropboxapi.com/2/files/upload',{
            method: 'POST',
            headers: {  
                'Content-Type': "application/octet-stream",
                'Authorization': `Bearer ${this.ACCESS_TOKEN}`,
                'Dropbox-API-Arg': JSON.stringify(data)
            },
            body: file
        })
        return request.then((res) => {
            if(res.status === 200){
                console.log(`Success: ${res.statusText}`)
                return 'ok'
            }
            else{
                console.log(`Error ${res.status}: ${res.statusText}`)
                return `Error ${res.status}: ${res.statusText}`
            }
        })
        .catch(e => {
            console.log(`Error: ${e}`)
            return 'err'
        }) 
    }

    GetFile (path) {
        const data = {
            path: path
        }
        const request = fetch('https://api.dropboxapi.com/2/files/get_temporary_link',{
            method: 'POST',
            headers: {  
                'Content-Type': "application/json",
                'Authorization': `Bearer ${this.ACCESS_TOKEN}`
            },
            body: JSON.stringify(data) 
        })
        return request.then((res) => {
            if(res.status === 200){
                console.log(`Success: ${res.statusText}`)
                return res.json()
                    .then(data => {
                        return data.metadata.id
                    })
            }
            else{
                console.log(`Error ${res.status}: ${res.statusText}`)
                return `Error ${res.status}: ${res.statusText}`
            }
        })
        .catch(e =>{
            console.log(`Error: ${e}`)
            return 'err'
        })
    }

    GetList (foldername) {
        const data = {
            "path": `/${foldername}`,
            "recursive": false,
            "include_media_info": false,
            "include_deleted": false,
            "include_has_explicit_shared_members": false,
            "include_mounted_folders": true,
            "include_non_downloadable_files": true
        }
        const request = fetch('https://api.dropboxapi.com/2/files/list_folder',{
            method: 'POST',
            headers: {  
                'Content-Type': "application/json",
                'Authorization': `Bearer ${this.ACCESS_TOKEN}`
            },
            body: JSON.stringify(data)
        })
        return request.then((res) => {
            if(res.status === 200){
                console.log(`Success: ${res.statusText}`)
                return res.json()
                    .then(data => {
                        return data.entries.map(el => ({id: el.id, name: el.name}))
                    })
            }
            else{
                console.log(`Error ${res.status}: ${res.statusText}`)
                return 'err'
            }
        })
        .catch(e =>{
            console.log(`Error: ${e}`)
            return 'err'
        })
    }

    DeleteFolderORFile (path) {
        const data = {
            "path": path
        }
        const request = fetch('https://api.dropboxapi.com/2/files/delete_v2',{
            method: 'POST',
            headers: {  
                'Content-Type': "application/json",
                'Authorization': `Bearer ${this.ACCESS_TOKEN}`
            },
            body: JSON.stringify(data)
        })
        return request.then((res) => {
            if(res.status === 200){
                console.log(`Success: ${res.statusText}`)
                return 'ok'
            }
            else{
                console.log(`Error ${res.status}: ${res.statusText}`)
                return `Error ${res.status}: ${res.statusText}`
            }
        })
        .catch(e =>{
            console.log(`Error: ${e}`)
            return 'err'
        })
    }
}

sol = new DropBoxSolution()



module.exports = DropBoxSolution;