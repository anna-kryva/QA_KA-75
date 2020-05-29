const DropBoxSolution = require('./index');

const main = () => {

  solution = new DropBoxSolution()

  test('Create Folder', async () => {
    let response = await solution.AddFolder('Naa11me')
    if(response === 'Error 409: Conflict') {
      await solution.DeleteFolderORFile('/Naa11me')
      response = await solution.AddFolder('Naa11me')
    }
    expect(response).toBe('ok');
  });

  test('Create and Add File', async () => {
    const response = await solution.AddFile('Naa11me', 'image0')
    expect(response).toBe('ok');
  });

  test('Delete File', async () => {
    const response = await solution.DeleteFolderORFile('/Naa11me/image0.png')
    expect(response).toBe("ok");
  });

  test('Delete Folder', async () => {
    const response = await solution.DeleteFolderORFile('/Naa11me')
    expect(response).toBe("ok");
  });


  test('Get File', async () => {
    const response = await solution.GetFile('/Naame/image3.png')
    expect(response).toBe('id:hqAV0jW3DzAAAAAAAAAALw');
  });

  test('Get List', async () => {
    const response = await solution.GetList('Naame')
    const p = Array.isArray(response)
    expect(p).toBe(true);
  });

  test('Create, Delete and Try to get deleted', async () => {
    await solution.AddFile('Naame', 'image10')
    await solution.DeleteFolderORFile('/Naame/image10.png')
    const response = await solution.GetFile('/Naame/image10.png')
    expect(response).toBe("Error 409: Conflict");
  });

}

main();