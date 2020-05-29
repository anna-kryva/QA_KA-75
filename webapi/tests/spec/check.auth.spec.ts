import { DropBoxClient } from "../../src/dropbox/client.implementation";

export async function checkAuth():Promise<boolean>{
    const client = new DropBoxClient();
    return await client.isAuth();
}

export default checkAuth;