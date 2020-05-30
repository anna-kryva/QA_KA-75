const DropBoxCommunicator = require('./index');

const main = () => {

  communicator = new DropBoxCommunicator();

  test('Get file metadata', async () => {
    const getMetadataresponse = await communicator.getMetadata('id:rB3op0c_o2AAAAAAAAAAEQ'); 

    expect(getMetadataresponse).toBe('ok');
  });

  test('Upload and delete', async () => {
    const uploadResponse = await communicator.upload('image.jpg', '/image.jpg'); 
    const deleteResponse = await communicator.delete('/image.jpg'); 

    expect(uploadResponse).toBe('ok');
    expect(deleteResponse).toBe('ok');
  });
}

main();
