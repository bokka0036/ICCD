# -*- coding: utf-8 -*-
"""LLMtest1.ipynb

Automatically generated by Colaboratory.

Original file is located at
    https://colab.research.google.com/drive/1kIRnsJIkO7ekQ29kg2ZjZjgsqgRXdUqV
"""

!pip install -q transformers accelerate sentencepiece bitsandbytes

# テキストが見やすいようにwrapしておく
from IPython.display import HTML, display

def set_css():
  display(HTML('''
  <style>
    pre {
        white-space: pre-wrap;
    }
  </style>
  '''))
get_ipython().events.register('pre_run_cell', set_css)

import torch
from transformers import (
    AutoTokenizer,
    AutoModelForCausalLM,
    BitsAndBytesConfig,
)

model_name = 'elyza/ELYZA-japanese-Llama-2-7b-fast-instruct'

quantization_config = BitsAndBytesConfig(
    load_in_4bit=True,
    bnb_4bit_compute_dtype=torch.bfloat16
)

tokenizer = AutoTokenizer.from_pretrained(model_name)
model = AutoModelForCausalLM.from_pretrained(
    model_name,
    device_map="auto",
    quantization_config=quantization_config,
)

B_INST, E_INST = "[INST]", "[/INST]"
B_SYS, E_SYS = "<<SYS>>\n", "\n<</SYS>>\n\n"
DEFAULT_SYSTEM_PROMPT = "あなたは誠実で優秀な日本人のアシスタントです。"

def build_prompt(text:str, system_prompt:str | None = None) -> str:
    system_prompt = system_prompt or DEFAULT_SYSTEM_PROMPT
    prompt = "{bos_token}{b_inst} {system}{prompt} {e_inst} ".format(
        bos_token=tokenizer.bos_token,
        b_inst=B_INST,
        system=f"{B_SYS}{system_prompt}{E_SYS}",
        prompt=text,
        e_inst=E_INST,
    )
    return prompt

build_prompt("1 + 1 は何ですか？")

"""下のコードのtextのところに入れたいプロンプトを書いてください。"""

text = """
今日の昼ごはんを一つ決めて下さい。
""".strip()
inputs = tokenizer(build_prompt(text), add_special_tokens=False, return_tensors='pt')

with torch.no_grad():
    output_ids = model.generate(
        inputs['input_ids'].to(model.device),
        max_new_tokens=256,
        do_sample=True,
        temperature=0.1,
        top_p=0.9,
        pad_token_id=tokenizer.pad_token_id,
        bos_token_id=tokenizer.bos_token_id,
        eos_token_id=tokenizer.eos_token_id,
        repetition_penalty=1.1,
    )

output = tokenizer.decode(output_ids.tolist()[0])
print(output)