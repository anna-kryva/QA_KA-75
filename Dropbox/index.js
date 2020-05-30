'use strict';

const dotenv = require('dotenv');
const fetch = require('node-fetch');
const fs = require('fs');


class DropboxCommunicator {

    CONTENT_ENDPOINT = 'https://content.dropboxapi.com/2/';
    RPC_ENDPOINT = 'https://api.dropboxapi.com/2/';

    constructor() {
        dotenv.config();
        this.TOKEN = process.env.DROPBOX_KEY;
    }

    upload(localPath, dropboxPath) {
        const content = fs.createReadStream(localPath);
        const request = this.post(
            `${this.CONTENT_ENDPOINT}files/upload`, 
            'application/octet-stream', content, { 
                path : dropboxPath,
                mode : 'add',
                autorename : true,
                mute : false,
                strict_conflict : false
        });

        return this.processResult(request);
    }

    delete(path) {
        const request = this.post(
            `${this.RPC_ENDPOINT}files/delete_v2`, 
            'application/json', { path }
        );

        return this.processResult(request);
    }


    getMetadata(path) {
        const request = this.post(
            `${this.RPC_ENDPOINT}sharing/get_file_metadata`, 
            'application/json', { path }
        );
        const proc = (res) => res.json().then(
            data => { 
                console.log('Link: ' + data.link);
                return 'ok';
        });
        
        return this.processResult(request, proc);
    }

    post(url, type, body, apiArgs) {
        const dct = {
            method : 'POST',
            headers : {
                'Content-Type' : type,
                'Authorization' : 'Bearer ' + this.TOKEN,
            },
            body : JSON.stringify(body)
        };

        if (apiArgs) {
            dct['headers']['Dropbox-API-Arg'] = JSON.stringify(apiArgs);
        }

        return fetch(url, dct);
    }

    processResult = (prom, proc) => {
        return prom.then((res) => {
            if (res.status === 200) {
                console.log(`Success: ${res.statusText}`);
                return proc === undefined ? 'ok' : proc(res);
            } else {
                console.log(`Error ${res.status}: ${res.statusText}`);
                return `Error ${res.status}: ${res.statusText}`;
            }
        }).catch(e => {
            console.log(`Error: ${e}`);
            return 'err';
        });
    };
}

module.exports = DropboxCommunicator;
