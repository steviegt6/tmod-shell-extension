use windows::{
    core::{implement, Result, GUID, HRESULT, PCWSTR, PWSTR},
    Win32::{Foundation::BOOL, System::Com::{IPersistFile, IPersistFile_Impl, IPersist_Impl, STGM}},
};

#[implement(IPersistFile)]
struct ShellExtension;

impl IPersist_Impl for ShellExtension {
    fn GetClassID(&self) ->  Result<GUID> {
        todo!()
    }
}

impl IPersistFile_Impl for ShellExtension {
    fn IsDirty(&self) -> HRESULT {
        todo!()
    }

    fn Load(&self, pszfilename: &PCWSTR, dwmode: STGM) -> Result<()> {
        todo!()
    }

    fn Save(
        &self,
        pszfilename: &PCWSTR,
        fremember: BOOL,
    ) -> Result<()> {
        todo!()
    }

    fn SaveCompleted(&self, pszfilename: &PCWSTR) -> Result<()> {
        todo!()
    }

    fn GetCurFile(&self) -> Result<PWSTR> {
        todo!()
    }
}
