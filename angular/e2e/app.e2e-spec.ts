import { QuanLySinhVienTemplatePage } from './app.po';

describe('QuanLySinhVien App', function() {
  let page: QuanLySinhVienTemplatePage;

  beforeEach(() => {
    page = new QuanLySinhVienTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
