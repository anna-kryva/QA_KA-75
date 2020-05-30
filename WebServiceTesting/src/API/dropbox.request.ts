import superagent, { SuperAgentStatic } from 'superagent';
import dotenv from "dotenv";
import IResponse from './interfaces';

abstract class DropboxRequest {
  protected request: SuperAgentStatic;

  protected constructor() {
    dotenv.config();
    const token: string = String(process.env.DROPBOX_TOKEN);
    this.request = superagent.agent()
        .auth(token, {type: 'bearer'});
  }

  protected getResponse(originResponse: any): IResponse {
    return {
      name: originResponse.name,
      id: originResponse.id,
      rev: originResponse.rev,
      size: originResponse.size,
      is_downloadable: originResponse.is_downloadable,
    }
  }
}

export default DropboxRequest;
