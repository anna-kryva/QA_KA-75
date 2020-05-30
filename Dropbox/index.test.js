const DropBoxCommunicator = require('./index');

const main = () => {

  communicator = new DropBoxCommunicator();

  test('Get file metadata', async () => {
    const uploadResponse = await communicator.upload('image.jpg', '/image.jpg');
    const getMetadataresponse = await communicator.getMetadata('/image.jpg'); 

    expect(uploadResponse).toBe('ok');
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
