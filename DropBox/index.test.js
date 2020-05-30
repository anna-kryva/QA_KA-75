const DropBoxCommunicator = require('./index');

const main = () => {

  communicator = new DropBoxCommunicator();

  test('Upload file', async () => {
    const response = await communicator.upload('marla.jpg', '/marla.jpg'); 
    expect(response).toBe('ok');
  });

  test('Get temporary link', async () => {
    const response = await communicator.getTempLink('/marla.jpg'); 
    expect(response).toBe('ok');
  });

  test('Delete file', async () => {
    const response = await communicator.delete('/marla.jpg'); 
    expect(response).toBe('ok');
  });

  test('Upload and delete', async () => {
    const uploadResponse = await communicator.upload('marla.jpg', '/marla.jpg'); 
    const deleteResponse = await communicator.delete('/marla.jpg'); 

    expect(uploadResponse).toBe('ok');
    expect(deleteResponse).toBe('ok');
  });
}

main();
