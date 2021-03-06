import { Component, OnInit, ViewChild, ElementRef, Input, HostBinding, AfterViewInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'b-text-editor',
  templateUrl: './text-editor.component.html',
  providers: [{ provide: NG_VALUE_ACCESSOR, multi: true, useExisting: TextEditorComponent }]
})
export class TextEditorComponent implements ControlValueAccessor, AfterViewInit {

  // A simple text editor, instead of using input directly in all the screens, this allows
  // us to change the bahvior of all inputs in the application since they all use this control

  @Input()
  placeholder = '';

  @Input()
  focusIf: boolean;

  @HostBinding('class.w-100')
  w100 = true;

  ///////////////// Implementation of ControlValueAccessor
  @ViewChild('input')
  input: ElementRef;

  public isDisabled = false;
  public onChange: (val: any) => void = _ => { };
  public onTouched: () => void = () => { };
  public onValidatorChange: () => void = () => { };

  writeValue(v: any): void {

    v = v || '';
    this.input.nativeElement.value = v; // Format
  }

  registerOnChange(fn: (val: any) => void): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }


  ///////////////// Implementation of AfterViewInit
  ngAfterViewInit() {
    if (this.focusIf && this.input) {
      this.input.nativeElement.focus();
    }
  }

}
