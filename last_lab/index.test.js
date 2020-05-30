const DropBox = require('./index');
const main = () => {
  communicator = new DropBox();
  test('Upload a file', async () => {
    const response = await communicator.upload('cat.png', '/cat.png'); 
    expect(response).toBe('ok');
  });
  test('Move a file', async () => {
    const response = await communicator.move('/cat.png', '/dog.png'); 
    expect(response).toBe('ok');
  });
  test('Delete a file', async () => {
    const response = await communicator.delete('/dog.png'); 
    expect(response).toBe('ok');
  });
  test('Upload move and delete', async () => {
    const uploadResponse = await communicator.upload('cat.png', '/cat.png'); 
    expect(uploadResponse).toBe('ok');
    const moveResponse = await communicator.move('/cat.png', '/dog.png'); 
    expect(moveResponse).toBe('ok');
    const deleteResponse = await communicator.delete('/dog.png'); 
    expect(deleteResponse).toBe('ok');
  });
}

main();