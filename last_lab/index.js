var fetch = require('node-fetch');
var dotenv = require('dotenv');
var fs = require('fs');
class Dropbox {
    constructor() {
        dotenv.config();
        this.ACCESS_KEY = process.env.DROPBOX_KEY;
    }
    move(fromPath, toPath) {
        var request = fetch('https://api.dropboxapi.com/2/files/move_v2',{
            method : 'POST',
            headers : {
                'Content-Type' : 'application/json',
                'Authorization' : 'Bearer ' + this.ACCESS_KEY,
            },
            body : JSON.stringify({
                from_path : fromPath,
                to_path : toPath,
                allow_shared_folder : false,
                autorename : false,
                allow_ownership_transfer : false
            })
        });

        return request.then((result) => {
            if (result.status === 200) {
                console.log(`Success: ${result.statusText}`);
                return 'ok';
            } else {
                console.log(`Error ${result.status}: ${result.statusText}`);
                return `Error ${result.status}: ${result.statusText}`;
            }
        }).catch(e => {
            console.log(`Error: ${e}`);
            return 'err';
        });
    }
    upload(path, outPath) {
        var content = fs.createReadStream(path);
        var request = fetch('https://content.dropboxapi.com/2/files/upload', {
                method : 'POST',
                headers : {
                    'Content-Type' : 'application/octet-stream',
                    'Authorization' : 'Bearer ' + this.ACCESS_KEY,
                    'Dropbox-API-Arg' : JSON.stringify({ 
                        path : outPath,
                        mode : 'add',
                        autorename : true,
                        mute : false,
                        strict_conflict : false
                    })
                },
                body : content
            }
        );
        return request.then((result) => {
            if (result.status === 200) {
                console.log(`Success: ${result.statusText}`);
                return 'ok';
            } else {
                console.log(`Error ${result.status}: ${result.statusText}`);
                return `Error ${result.status}: ${result.statusText}`;
            }
        }).catch(e => {
            console.log(`Error: ${e}`);
            return 'err';
        });
    }
    delete(path) {
        var request = fetch('https://api.dropboxapi.com/2/files/delete_v2',{
            method : 'POST',
            headers : {
                'Content-Type' : 'application/json',
                'Authorization' : 'Bearer ' + this.ACCESS_KEY,
            },
            body : JSON.stringify({ path })
        });
        return request.then((result) => {
            if (result.status === 200) {
                console.log(`Success: ${result.statusText}`);
                return 'ok';
            } else {
                console.log(`Error ${result.status}: ${result.statusText}`);
                return `Error ${result.status}: ${result.statusText}`;
            }
        }).catch(e => {
            console.log(`Error: ${e}`);
            return 'err';
        });
    }
}
module.exports = Dropbox;