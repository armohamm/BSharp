import { Component, Input, ElementRef, ViewChild, HostBinding } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';

@Component({
  selector: 'b-selector',
  templateUrl: './selector.component.html',
  providers: [{ provide: NG_VALUE_ACCESSOR, multi: true, useExisting: SelectorComponent }]
})
export class SelectorComponent implements ControlValueAccessor {

  // Selector from a list of choices, instead of using selector directly in all the screens, this allows
  // us to change the bahvior of all inputs in the application since they all use this control

  @Input()
  isOptional = false;

  @Input()
  choices: { name: string, value: any }[] = [];

  @HostBinding('class.w-100')
  w100 = true;

  public nullValue = null;

  ///////////////// Implementation of ControlValueAccessor
  @ViewChild('selector')
  selector: ElementRef;

  public isDisabled = false;
  public onChange: (val: any) => void = _ => { };
  public onTouched: () => void = () => { };
  public onValidatorChange: () => void = () => { };

  writeValue(v: any): void {

    v = v || '';
    this.selector.nativeElement.value = v; // Format
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

}
